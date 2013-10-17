using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class locales_gossip_menu_optionMap : EntityTypeConfiguration<locales_gossip_menu_option>
    {
        public locales_gossip_menu_optionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.menu_id, t.id });

            // Properties
            this.Property(t => t.menu_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.option_text_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.option_text_loc8)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc1)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc2)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc3)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc4)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc5)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc6)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc7)
                .HasMaxLength(65535);

            this.Property(t => t.box_text_loc8)
                .HasMaxLength(65535);

        }
    }
}
