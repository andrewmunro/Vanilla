using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class creature_linking_templateMap : EntityTypeConfiguration<creature_linking_template>
    {
        public creature_linking_templateMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.map });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.map)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
