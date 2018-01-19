using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POCOData.Models
{
    [Table("Clusters")]
    public class Cluster : PlusAdviesModel
    {
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Naam { get; set; }

        public virtual ICollection<SubAgent> SubAgents { get; set; } = new List<SubAgent>();

    }
}