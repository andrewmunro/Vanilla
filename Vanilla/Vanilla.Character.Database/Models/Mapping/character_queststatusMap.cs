using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_queststatusMap : EntityTypeConfiguration<character_queststatus>
    {
        public character_queststatusMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.quest });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.quest)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
