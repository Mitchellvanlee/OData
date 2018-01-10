using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;
using POCOData.Context;

namespace POCOData.Controllers
{
    [EnableQuery]
    [ODataRoutePrefix("Verkopers")]
    public class VerkopersController : ODataController
    {
        ODataPOCContext context = new ODataPOCContext();

        [HttpGet]
        public IHttpActionResult GetContracten()
        {
            return Ok(context.Verkopers);
            //return Ok(CreateCurrentView());
        }

    }
}