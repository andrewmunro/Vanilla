using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class PlayerCreateInfoItemMap : EntityTypeConfiguration<PlayerCreateInfoItem>
    {
        public PlayerCreateInfoItemMap()
        {
            // Primary Key
            this.HasKey(t => new { race = t.Race, t.Class, itemid = t.Itemid, amount = t.Amount });

            // Properties
            this.Property(t => t.Itemid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
