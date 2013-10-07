using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class character_actionMap : EntityTypeConfiguration<character_action>
    {
        public character_actionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.button });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
