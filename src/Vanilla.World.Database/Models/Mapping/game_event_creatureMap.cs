using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class game_event_creatureMap : EntityTypeConfiguration<game_event_creature>
    {
        public game_event_creatureMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
