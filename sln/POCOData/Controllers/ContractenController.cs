using System.Collections.Generic;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using POCOData.Context;
using POCOData.Models;
using System.Linq;

namespace POCOData.Controllers
{
    [EnableQuery]
    [ODataRoutePrefix("Contracten")]
    public class ContractenController : ODataController
    {
        ODataPOCContext context = new ODataPOCContext();

        [HttpGet]
        public IHttpActionResult GetContracten()
        {
            return Ok(context.Contracten);
            //return Ok(CreateCurrentView());
        }

        private IEnumerable<CurrentView> CreateCurrentView()
        {
            return context.Contracten
                .GroupBy(contract => new {Financiering = contract.Financiering})
                .Select(grouping => new CurrentView()
                {
                    Financiering = grouping.Count(r => r.Financiering == Contract.ContractType.Financiering),
                    Verzekering = grouping.Count(r => r.Financiering == Contract.ContractType.Verzekering),
                    Totaal = grouping.Count(r =>
                        r.Financiering == Contract.ContractType.Financiering ||
                        r.Financiering == Contract.ContractType.Financiering)
                });
        }

        public class CurrentView
        {
            public int Financiering { get; set; }
            public int Verzekering { get; set; }
            public int Totaal { get; set; }
        }

        //        [HttpGet]
        //        [ODataRoute("ODataPOC.GetContractenByYear()")]
        //        public IHttpActionResult GetContractenByYear()
        //        {
        //            return Ok(context.Contracten.GroupBy(contract => contract.Jaar).Count());
        //        }
        //        public IQueryable<VerkoopPerVerkoperPerLocatiePerMaandPerJaarView> CreateVerkoopPerVerkoperPerLocatiePerMaandPerJaarViews()
        //        {
        //            IQueryable<VerkoopPerVerkoperPerLocatiePerMaandPerJaarView> result = _context.Contracten
        //                .AsExpressionProjectable()
        //                .Where(c => c != null)
        //                .Where(c => c.Verkoper != null)
        //                .Where(c => c.Verkoper.Naam != null)
        //                .Where(c => c.Verkoper.SubAgent != null)
        //                .GroupBy(contract => new
        //                {
        //                    Jaar = CalculateGroupingDatumExpression.Project(contract).Year,
        //                    Maand = CalculateGroupingDatumExpression.Project(contract).Month,
        //                    Verkoper = contract.Verkoper,
        //                    SubAgent = contract.Verkoper.SubAgent
        //                })
        //                .Select(r => new VerkoopPerVerkoperPerLocatiePerMaandPerJaarView()
        //                {
        //                    Verkoper = r.Key.Verkoper.Naam,
        //                    VerkoperId = r.Key.Verkoper.Id,
        //                    Jaar = r.Key.Jaar,
        //                    Maand = r.Key.Maand,
        //                    SubAgent = r.Key.SubAgent.Naam,
        //                    Financiering = r.Key.Verkoper.Contracten
        //                        .GroupBy(re => new { Jaar = r.Key.Jaar, Maand = r.Key.Maand })
        //                        .Sum(re => r.Key.Verkoper.Contracten
        //                            .Where(c => CalculateGroupingDatumExpression.Project(c).Year == re.Key.Jaar &&
        //                                        CalculateGroupingDatumExpression.Project(c).Month == re.Key.Maand)
        //                            .Count(c => c.Financiering == ContractType.Financiering)),
        //                    Verzekering = r.Key.Verkoper.Contracten
        //                        .GroupBy(re => new { Jaar = r.Key.Jaar, Maand = r.Key.Maand })
        //                        .Sum(re => r.Key.Verkoper.Contracten
        //                            .Where(c => CalculateGroupingDatumExpression.Project(c).Year == re.Key.Jaar &&
        //                                        CalculateGroupingDatumExpression.Project(c).Month == re.Key.Maand)
        //                            .Count(c => c.Financiering == ContractType.Verzekering)),
        //                    Totaal = r.Key.Verkoper.Contracten
        //                        .GroupBy(re => new { Jaar = r.Key.Jaar, Maand = r.Key.Maand })
        //                        .Sum(re => r.Key.Verkoper.Contracten
        //                            .Where(c => CalculateGroupingDatumExpression.Project(c).Year == re.Key.Jaar &&
        //                                        CalculateGroupingDatumExpression.Project(c).Month == re.Key.Maand)
        //                            .Count(c => c.Financiering == ContractType.Verzekering ||
        //                                        c.Financiering == ContractType.Financiering))
        //                });
        //            return result;
        //        }
    }
}