using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POCOData.Models
{
    [Table("Verkopers")]
    public class Verkoper : PlusAdviesModel
    {
        [StringLength(100)]
        public string Naam { get; set; }

        public virtual SubAgent SubAgent { get; set; }

        public virtual ICollection<Contract> Contracten { get; set; } = new List<Contract>();
    }
}