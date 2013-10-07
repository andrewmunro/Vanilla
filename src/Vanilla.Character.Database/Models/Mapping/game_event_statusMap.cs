using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class game_event_statusMap : EntityTypeConfiguration<game_event_status>
    {
        public game_event_statusMap()
        {
            // Primary Key
            this.HasKey(t => t.event);

            // Properties
            this.Property(t => t.event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
