using System.Web.OData.Builder;

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