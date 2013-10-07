using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class commandMap : EntityTypeConfiguration<command>
    {
        public commandMap()
        {
            // Primary Key
            this.HasKey(t => t.name);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.help)
                .HasMaxLength(1073741823);

        }
    }
}
