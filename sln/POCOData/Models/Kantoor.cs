using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POCOData.Models
{
    [Table("Kantoren")]
    public class Kantoor : PlusAdviesModel
    {
        [StringLength(100)]
        public string Naam { get; set; }

        public virtual ICollection<AccountManager> AccountManagers { get; set; } = new List<AccountManager>();
        public virtual ICollection<SubAgent> SubAgenten { get; set; } = new List<SubAgent>();

        public Kantoor()
        {
        }
    }
}