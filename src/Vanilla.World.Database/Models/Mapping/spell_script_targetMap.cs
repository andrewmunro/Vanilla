using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class spell_script_targetMap : EntityTypeConfiguration<spell_script_target>
    {
        public spell_script_targetMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.type, t.targetEntry, t.inverseEffectMask });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.targetEntry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.inverseEffectMask)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
