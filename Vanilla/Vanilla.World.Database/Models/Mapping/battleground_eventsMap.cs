using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class battleground_eventsMap : EntityTypeConfiguration<battleground_events>
    {
        public battleground_eventsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.map, t.event1, t.event2 });

            // Properties
            this.Property(t => t.map)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
