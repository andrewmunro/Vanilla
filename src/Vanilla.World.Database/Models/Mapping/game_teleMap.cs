using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class game_teleMap : EntityTypeConfiguration<game_tele>
    {
        public game_teleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
