using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class uptimeMap : EntityTypeConfiguration<uptime>
    {
        public uptimeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.realmid, t.starttime });

            // Properties
            this.Property(t => t.realmid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.starttime)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.startstring)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
