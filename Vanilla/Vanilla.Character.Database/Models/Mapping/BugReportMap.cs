using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class BugreportMap : EntityTypeConfiguration<BugReport>
    {
        public BugreportMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(1073741823);

            this.Property(t => t.Content)
                .IsRequired()
                .HasMaxLength(1073741823);

        }
    }
}
