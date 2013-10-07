using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class creature_movementMap : EntityTypeConfiguration<creature_movement>
    {
        public creature_movementMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.point });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.point)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
