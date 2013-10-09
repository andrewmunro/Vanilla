using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class PlayerCreateInfoMap : EntityTypeConfiguration<PlayerCreateInfo>
    {
        public PlayerCreateInfoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Race, t.Class });

            // Properties
        }
    }
}
