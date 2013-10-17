using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class locales_itemMap : EntityTypeConfiguration<locales_item>
    {
        public locales_itemMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name_loc1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc2)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc3)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc4)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc5)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc6)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc7)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.name_loc8)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.description_loc1)
                .HasMaxLength(255);

            this.Property(t => t.description_loc2)
                .HasMaxLength(255);

            this.Property(t => t.description_loc3)
                .HasMaxLength(255);

            this.Property(t => t.description_loc4)
                .HasMaxLength(255);

            this.Property(t => t.description_loc5)
                .HasMaxLength(255);

            this.Property(t => t.description_loc6)
                .HasMaxLength(255);

            this.Property(t => t.description_loc7)
                .HasMaxLength(255);

            this.Property(t => t.description_loc8)
                .HasMaxLength(255);

        }
    }
}
