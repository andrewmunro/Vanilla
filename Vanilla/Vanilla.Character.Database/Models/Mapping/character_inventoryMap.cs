using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_inventoryMap : EntityTypeConfiguration<character_inventory>
    {
        public character_inventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.item);

            // Properties
            this.Property(t => t.item)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
