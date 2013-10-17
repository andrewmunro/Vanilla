using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class game_weatherMap : EntityTypeConfiguration<game_weather>
    {
        public game_weatherMap()
        {
            // Primary Key
            this.HasKey(t => t.zone);

            // Properties
            this.Property(t => t.zone)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
