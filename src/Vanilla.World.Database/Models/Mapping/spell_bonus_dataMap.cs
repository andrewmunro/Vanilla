using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class spell_bonus_dataMap : EntityTypeConfiguration<spell_bonus_data>
    {
        public spell_bonus_dataMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.comments)
                .HasMaxLength(255);

        }
    }
}
