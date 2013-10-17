using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class creature_movement_templateMap : EntityTypeConfiguration<creature_movement_template>
    {
        public creature_movement_templateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.point });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.point)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
