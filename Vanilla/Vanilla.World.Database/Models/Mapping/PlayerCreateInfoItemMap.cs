using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class PlayerCreateInfoItemMap : EntityTypeConfiguration<PlayerCreateInfoItem>
    {
        public PlayerCreateInfoItemMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Race, t.Class, t.Itemid, t.Amount });

            // Properties
            this.Property(t => t.Itemid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
