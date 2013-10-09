using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class playerClassLevelStatsMap : EntityTypeConfiguration<PlayerClassLevelStats>
    {
        public playerClassLevelStatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Class, level = t.Level });

            // Properties
        }
    }
}
