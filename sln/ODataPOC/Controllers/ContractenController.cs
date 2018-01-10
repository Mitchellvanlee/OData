using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using ODataPOC.Context;

namespace ODataPOC.Controllers
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
            //return Ok(context.Contracten.GroupBy(contract => contract.Jaar).Count());
        }

//        [HttpGet]
//        [ODataRoute("ODataPOC.GetContractenByYear()")]
//        public IHttpActionResult GetContractenByYear()
//        {
//            return Ok(context.Contracten.GroupBy(contract => contract.Jaar).Count());
//        }
    }
}