namespace Vanilla.Login.Database.Models
{
    using System.Data.Entity;
    using Vanilla.Login.Database.Models.Mapping;

    public class LoginDatabase : DbContext
    {
        static LoginDatabase()
        {
            Database.SetInitializer<LoginDatabase>(null);
        }

        public LoginDatabase()
            : base("Name=LoginDatabase")
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountBanned> AccountBanned { get; set; }

        public DbSet<IPBanned> IpBanned { get; set; }

        public DbSet<RealmCharacter> Realmcharacters { get; set; }

        public DbSet<RealmList> Realmlists { get; set; }

        public DbSet<UpTime> Uptimes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new AccountBannedMap());
            modelBuilder.Configurations.Add(new IPBannedMap());
            modelBuilder.Configurations.Add(new RealmCharacterMap());
            modelBuilder.Configurations.Add(new RealmListMap());
            modelBuilder.Configurations.Add(new UpTimeMap());
        }
    }
}
