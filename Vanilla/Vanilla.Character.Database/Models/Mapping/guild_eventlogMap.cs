using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class guild_eventlogMap : EntityTypeConfiguration<guild_eventlog>
    {
        public guild_eventlogMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guildid, t.LogGuid });

            // Properties
            this.Property(t => t.guildid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.LogGuid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
