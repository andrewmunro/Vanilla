using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class spell_areaMap : EntityTypeConfiguration<spell_area>
    {
        public spell_areaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.spell, t.area, t.quest_start, t.quest_start_active, t.aura_spell, t.racemask, t.gender });

            // Properties
            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.area)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.quest_start)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.aura_spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.racemask)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
