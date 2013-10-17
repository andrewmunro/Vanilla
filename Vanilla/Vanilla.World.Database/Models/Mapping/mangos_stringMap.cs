using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class mangos_stringMap : EntityTypeConfiguration<mangos_string>
    {
        public mangos_stringMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.content_default)
                .IsRequired()
                .HasMaxLength(65535);

            this.Property(t => t.content_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.content_loc8)
                .HasMaxLength(65535);

        }
    }
}
