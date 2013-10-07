using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class game_event_questMap : EntityTypeConfiguration<game_event_quest>
    {
        public game_event_questMap()
        {
            // Primary Key
            this.HasKey(t => new { t.quest, t.event });

            // Properties
            this.Property(t => t.quest)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
