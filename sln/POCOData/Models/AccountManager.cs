using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace POCOData.Models
{
    [Table("AccountManagers")]
    public class AccountManager : PlusAdviesModel
    {
        [StringLength(50)]
        public string Naam { get; set; }

        [ForeignKey("Kantoor")]
        public int KantoorId { get; set; }
        public virtual Kantoor Kantoor { get; set; }
        public virtual ICollection<Contract> Contracten { get; set; } = new List<Contract>();

        public AccountManager()
        {
        }
    }
}