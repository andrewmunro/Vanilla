using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class reputation_spillover_templateMap : EntityTypeConfiguration<reputation_spillover_template>
    {
        public reputation_spillover_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.faction);

            // Properties
            this.Property(t => t.faction)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
