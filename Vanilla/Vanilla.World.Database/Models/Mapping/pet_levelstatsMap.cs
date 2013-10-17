using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class pet_levelstatsMap : EntityTypeConfiguration<pet_levelstats>
    {
        public pet_levelstatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.creature_entry, t.level });

            // Properties
            this.Property(t => t.creature_entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
