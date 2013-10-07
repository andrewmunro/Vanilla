using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class item_instanceMap : EntityTypeConfiguration<item_instance>
    {
        public item_instanceMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data)
                .HasMaxLength(1073741823);

        }
    }
}
