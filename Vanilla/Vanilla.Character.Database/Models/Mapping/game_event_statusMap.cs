using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class game_event_statusMap : EntityTypeConfiguration<GameEventStatus>
    {
        public game_event_statusMap()
        {
            // Primary Key
            this.HasKey(t => t.Event);

            // Properties
            this.Property(t => t.Event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
