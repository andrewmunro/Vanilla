using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class game_event_creature_dataMap : EntityTypeConfiguration<GameEventCreatureData>
    {
        public game_event_creature_dataMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GUID, t.Event });

            // Properties
            this.Property(t => t.GUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
