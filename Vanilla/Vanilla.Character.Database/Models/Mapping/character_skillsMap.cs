using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_skillsMap : EntityTypeConfiguration<character_skills>
    {
        public character_skillsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.skill });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.skill)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
