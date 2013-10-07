using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class realmcharacterMap : EntityTypeConfiguration<realmcharacter>
    {
        public realmcharacterMap()
        {
            // Primary Key
            this.HasKey(t => new { t.realmid, t.acctid });

            // Properties
            this.Property(t => t.realmid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.acctid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
