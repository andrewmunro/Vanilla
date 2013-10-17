using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class reputation_reward_rateMap : EntityTypeConfiguration<reputation_reward_rate>
    {
        public reputation_reward_rateMap()
        {
            // Primary Key
            this.HasKey(t => t.faction);

            // Properties
            this.Property(t => t.faction)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
