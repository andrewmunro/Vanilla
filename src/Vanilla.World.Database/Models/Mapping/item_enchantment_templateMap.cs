using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class item_enchantment_templateMap : EntityTypeConfiguration<item_enchantment_template>
    {
        public item_enchantment_templateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.ench });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ench)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
