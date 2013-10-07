using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class creatureMap : EntityTypeConfiguration<creature>
    {
        public creatureMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
        }
    }
}
