using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class player_levelstatsMap : EntityTypeConfiguration<player_levelstats>
    {
        public player_levelstatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.race, t.class, t.level });

            // Properties
        }
    }
}
