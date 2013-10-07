using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class gossip_menuMap : EntityTypeConfiguration<gossip_menu>
    {
        public gossip_menuMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.text_id, t.script_id });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.text_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.script_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
