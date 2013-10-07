using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class character_spellMap : EntityTypeConfiguration<character_spell>
    {
        public character_spellMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.spell });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
