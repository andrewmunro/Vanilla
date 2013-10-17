using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_petMap : EntityTypeConfiguration<character_pet>
    {
        public character_petMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .HasMaxLength(100);

            this.Property(t => t.abdata)
                .HasMaxLength(1073741823);

            this.Property(t => t.teachspelldata)
                .HasMaxLength(1073741823);

        }
    }
}
