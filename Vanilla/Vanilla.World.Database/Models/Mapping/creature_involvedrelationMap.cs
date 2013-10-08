using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_involvedrelationMap : EntityTypeConfiguration<creature_involvedrelation>
    {
        public creature_involvedrelationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.quest });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.quest)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
