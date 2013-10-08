using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class gameobjectMap : EntityTypeConfiguration<gameobject>
    {
        public gameobjectMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
        }
    }
}
