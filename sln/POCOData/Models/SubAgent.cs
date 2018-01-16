using System.Web.OData.Builder;

namespace POCOData.Models
{
    public class SubAgent
    {
        public int SubAgentId { get; set; }
        public string Naam { get; set; }
        [AutoExpand]
        public Cluster Cluster { get; set; }
    }
}