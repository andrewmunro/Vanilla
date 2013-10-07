using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
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
