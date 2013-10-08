using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class game_event_mailMap : EntityTypeConfiguration<game_event_mail>
    {
        public game_event_mailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.event, t.raceMask, t.quest });

            // Properties
            this.Property(t => t.event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.raceMask)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.quest)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
