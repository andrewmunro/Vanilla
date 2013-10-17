using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class locales_points_of_interestMap : EntityTypeConfiguration<locales_points_of_interest>
    {
        public locales_points_of_interestMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.icon_name_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.icon_name_loc8)
                .HasMaxLength(65535);

        }
    }
}
