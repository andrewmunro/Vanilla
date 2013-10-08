using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class spell_learn_spellMap : EntityTypeConfiguration<spell_learn_spell>
    {
        public spell_learn_spellMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.SpellID });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SpellID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
