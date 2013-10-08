using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_templateMap : EntityTypeConfiguration<creature_template>
    {
        public creature_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.subname)
                .HasMaxLength(100);

            this.Property(t => t.AIName)
                .HasMaxLength(64);

            this.Property(t => t.ScriptName)
                .HasMaxLength(64);

        }
    }
}
