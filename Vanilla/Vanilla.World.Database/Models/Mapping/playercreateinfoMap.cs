using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class playercreateinfoMap : EntityTypeConfiguration<playercreateinfo>
    {
        public playercreateinfoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.race, t.class });

            // Properties
        }
    }
}
