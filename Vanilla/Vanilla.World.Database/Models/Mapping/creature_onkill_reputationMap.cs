using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_onkill_reputationMap : EntityTypeConfiguration<creature_onkill_reputation>
    {
        public creature_onkill_reputationMap()
        {
            // Primary Key
            this.HasKey(t => t.creature_id);

            // Properties
            this.Property(t => t.creature_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
