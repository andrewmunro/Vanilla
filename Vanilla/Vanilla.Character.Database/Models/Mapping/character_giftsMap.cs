using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_giftsMap : EntityTypeConfiguration<character_gifts>
    {
        public character_giftsMap()
        {
            // Primary Key
            this.HasKey(t => t.item_guid);

            // Properties
            this.Property(t => t.item_guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
