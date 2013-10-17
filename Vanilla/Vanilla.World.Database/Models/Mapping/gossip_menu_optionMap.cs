using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class gossip_menu_optionMap : EntityTypeConfiguration<gossip_menu_option>
    {
        public gossip_menu_optionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.menu_id, t.id });

            // Properties
            this.Property(t => t.menu_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.option_text)
                .HasMaxLength(65535);

            this.Property(t => t.box_text)
                .HasMaxLength(65535);

        }
    }
}
