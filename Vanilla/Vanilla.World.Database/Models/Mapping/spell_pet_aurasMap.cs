using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class spell_pet_aurasMap : EntityTypeConfiguration<spell_pet_auras>
    {
        public spell_pet_aurasMap()
        {
            // Primary Key
            this.HasKey(t => new { t.spell, t.pet });

            // Properties
            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pet)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
