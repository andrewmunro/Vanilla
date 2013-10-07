using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class item_templateMap : EntityTypeConfiguration<item_template>
    {
        public item_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ScriptName)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
