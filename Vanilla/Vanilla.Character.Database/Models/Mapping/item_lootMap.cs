using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class item_lootMap : EntityTypeConfiguration<item_loot>
    {
        public item_lootMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.itemid });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.itemid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
