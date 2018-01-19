using System.Data.Entity;
using POCOData.Models;

namespace POCOData.Context
{
    public class ODataPOCContext : DbContext
    {
        public DbSet<Contract> Contracten { get; set; }
        public DbSet<Kantoor> Kantoren { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }
        public DbSet<SubAgent> SubAgenten { get; set; }
        public DbSet<Verkoper> Verkopers { get; set; }
        public DbSet<Cluster> Clusters { get; set; }

        public ODataPOCContext() : base("PlusAdviesDbPOC")
        {
        }
    }
}

