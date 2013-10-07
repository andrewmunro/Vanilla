using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class creature_ai_scriptsMap : EntityTypeConfiguration<creature_ai_scripts>
    {
        public creature_ai_scriptsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.comment)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
