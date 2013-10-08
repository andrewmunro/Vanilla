using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class game_graveyard_zoneMap : EntityTypeConfiguration<game_graveyard_zone>
    {
        public game_graveyard_zoneMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.ghost_zone });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ghost_zone)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
