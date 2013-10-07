using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class spell_threatMap : EntityTypeConfiguration<spell_threat>
    {
        public spell_threatMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
