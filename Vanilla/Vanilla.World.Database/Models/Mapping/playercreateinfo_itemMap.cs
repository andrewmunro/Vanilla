using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class playercreateinfo_itemMap : EntityTypeConfiguration<playercreateinfo_item>
    {
        public playercreateinfo_itemMap()
        {
            // Primary Key
            this.HasKey(t => new { t.race, t.class, t.itemid, t.amount });

            // Properties
            this.Property(t => t.itemid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
