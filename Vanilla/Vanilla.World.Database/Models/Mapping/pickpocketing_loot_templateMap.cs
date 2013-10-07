using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class pickpocketing_loot_templateMap : EntityTypeConfiguration<pickpocketing_loot_template>
    {
        public pickpocketing_loot_templateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.item });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.item)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
