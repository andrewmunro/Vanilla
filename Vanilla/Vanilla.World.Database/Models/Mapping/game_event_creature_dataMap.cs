using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class game_event_creature_dataMap : EntityTypeConfiguration<game_event_creature_data>
    {
        public game_event_creature_dataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.event });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
