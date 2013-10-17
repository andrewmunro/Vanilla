using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class mail_itemsMap : EntityTypeConfiguration<mail_items>
    {
        public mail_itemsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.mail_id, t.item_guid });

            // Properties
            this.Property(t => t.mail_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.item_guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
