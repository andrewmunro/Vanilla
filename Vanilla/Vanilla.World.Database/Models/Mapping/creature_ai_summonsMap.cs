using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_ai_summonsMap : EntityTypeConfiguration<creature_ai_summons>
    {
        public creature_ai_summonsMap()
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
