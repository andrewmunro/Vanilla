using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class character_reputationMap : EntityTypeConfiguration<character_reputation>
    {
        public character_reputationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.faction });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.faction)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
