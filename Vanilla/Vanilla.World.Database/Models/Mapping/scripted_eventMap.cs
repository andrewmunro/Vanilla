using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class scripted_eventMap : EntityTypeConfiguration<scripted_event>
    {
        public scripted_eventMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ScriptName)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
