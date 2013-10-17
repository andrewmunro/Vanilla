using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class npc_trainerMap : EntityTypeConfiguration<npc_trainer>
    {
        public npc_trainerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.spell, t.spellcost, t.reqskill, t.reqskillvalue, t.reqlevel });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spellcost)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.reqskill)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.reqskillvalue)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
