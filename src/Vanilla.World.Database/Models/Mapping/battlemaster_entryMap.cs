using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class battlemaster_entryMap : EntityTypeConfiguration<battlemaster_entry>
    {
        public battlemaster_entryMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
