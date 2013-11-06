using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class playerClassLevelStatsMap : EntityTypeConfiguration<PlayerClassLevelStats>
    {
        public playerClassLevelStatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Class, t.Level });

            // Properties
        }
    }
}
