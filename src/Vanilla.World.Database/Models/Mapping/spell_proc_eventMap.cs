using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class spell_proc_eventMap : EntityTypeConfiguration<spell_proc_event>
    {
        public spell_proc_eventMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
