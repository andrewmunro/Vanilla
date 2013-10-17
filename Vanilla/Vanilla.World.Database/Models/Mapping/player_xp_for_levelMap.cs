using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class player_xp_for_levelMap : EntityTypeConfiguration<player_xp_for_level>
    {
        public player_xp_for_levelMap()
        {
            // Primary Key
            this.HasKey(t => t.lvl);

            // Properties
            this.Property(t => t.lvl)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
