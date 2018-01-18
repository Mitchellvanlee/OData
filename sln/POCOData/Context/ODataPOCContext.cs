using System.Collections.Generic;
using System.Data.Entity;
using PlusAdvies.Api.Models;
using POCOData.Models;

namespace POCOData.Context
{
    //Test data contains:
    //2000: 3 financiering / 3 verzekering
    //2001: 5 financiering / 3 verzekering
    //2010: 1 financiering / 0 verzekering
    public class ODataPOCContext : DbContext
    {
        public DbSet<Contract> Contracten { get; set; }
        public DbSet<Kantoor> Kantoren { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }
        public DbSet<SubAgent> SubAgenten { get; set; }
        public DbSet<Verkoper> Verkopers { get; set; }
        public DbSet<LastExecuted> LastExecuted { get; set; }
        public DbSet<Cluster> Clusters { get; set; }

        public PaContext() : base("PlusAdviesDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaContext, Migrations.Configuration>());
        }
    }
}

