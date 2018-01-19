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
    }
}