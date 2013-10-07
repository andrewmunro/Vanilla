using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class bugreportMap : EntityTypeConfiguration<bugreport>
    {
        public bugreportMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.type)
                .IsRequired()
                .HasMaxLength(1073741823);

            this.Property(t => t.content)
                .IsRequired()
                .HasMaxLength(1073741823);

        }
    }
}
