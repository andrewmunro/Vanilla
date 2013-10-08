using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class instance_templateMap : EntityTypeConfiguration<instance_template>
    {
        public instance_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.map);

            // Properties
            this.Property(t => t.map)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScriptName)
                .IsRequired()
                .HasMaxLength(128);

        }
    }
}
