using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class pool_gameobject_templateMap : EntityTypeConfiguration<pool_gameobject_template>
    {
        public pool_gameobject_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
