using System.Collections.Generic;
using System.Web.OData.Query;

namespace ODataPOC.Models
{
    [Expand("SubAgent", "Contract", MaxDepth = 10)]
    public class Verkoper
    {
        public int VerkoperId { get; set; }
        public string Naam { get; set; }
        public SubAgent SubAgent { get; set; }
        public virtual ICollection<Contract> Contracten { get; set; } = new List<Contract>();
    }
}