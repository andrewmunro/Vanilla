using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class locales_page_textMap : EntityTypeConfiguration<locales_page_text>
    {
        public locales_page_textMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Text_loc1)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc2)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc3)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc4)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc5)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc6)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc7)
                .HasMaxLength(1073741823);

            this.Property(t => t.Text_loc8)
                .HasMaxLength(1073741823);

        }
    }
}
