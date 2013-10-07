using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class playercreateinfo_spellMap : EntityTypeConfiguration<playercreateinfo_spell>
    {
        public playercreateinfo_spellMap()
        {
            // Primary Key
            this.HasKey(t => new { t.race, t.class, t.Spell });

            // Properties
            this.Property(t => t.Spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Note)
                .HasMaxLength(255);

        }
    }
}
