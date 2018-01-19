using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POCOData.Models
{
    [Table("SubAgenten")]
    public class SubAgent : PlusAdviesModel
    {
        [StringLength(100)]
        public string Naam { get; set; }

        public virtual ICollection<Verkoper> Verkopers { get; set; } = new List<Verkoper>();
        public virtual Kantoor Kantoor { get; set; }
        public virtual Cluster Cluster { get; set; }
    }
}