using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class creature_questrelationMap : EntityTypeConfiguration<creature_questrelation>
    {
        public creature_questrelationMap()
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
