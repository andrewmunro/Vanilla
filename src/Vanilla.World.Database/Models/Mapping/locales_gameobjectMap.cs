using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class locales_gameobjectMap : EntityTypeConfiguration<locales_gameobject>
    {
        public locales_gameobjectMap()
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

        }
    }
}
