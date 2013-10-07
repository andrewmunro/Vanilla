using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class player_classlevelstatsMap : EntityTypeConfiguration<player_classlevelstats>
    {
        public player_classlevelstatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.class, t.level });

            // Properties
        }
    }
}
