using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Vanilla.Login.Database.Models.Mapping;

namespace Vanilla.Login.Database.Models
{
    public partial class LoginDatabase : DbContext
    {
        static LoginDatabase()
        {
            Database.SetInitializer<LoginDatabase>(null);
        }

        public LoginDatabase()
            : base("Name=realmdContext")
        {
        }

        public DbSet<account> accounts { get; set; }
        public DbSet<account_banned> account_banned { get; set; }
        public DbSet<ip_banned> ip_banned { get; set; }
        public DbSet<realmcharacter> realmcharacters { get; set; }
        public DbSet<realmlist> realmlists { get; set; }
        public DbSet<uptime> uptimes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new accountMap());
            modelBuilder.Configurations.Add(new account_bannedMap());
            modelBuilder.Configurations.Add(new ip_bannedMap());
            modelBuilder.Configurations.Add(new realmcharacterMap());
            modelBuilder.Configurations.Add(new realmlistMap());
            modelBuilder.Configurations.Add(new uptimeMap());
        }
    }
}
