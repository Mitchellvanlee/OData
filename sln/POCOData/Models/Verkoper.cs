using System.Collections.Generic;
using System.Web.OData.Builder;
using System.Web.OData.Query;

namespace POCOData.Models
{
    public class Verkoper
    {
        public int VerkoperId { get; set; }
        public string Naam { get; set; }
        [AutoExpand]
        public SubAgent SubAgent { get; set; }
    }
}