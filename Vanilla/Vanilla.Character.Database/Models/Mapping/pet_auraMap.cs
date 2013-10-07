using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class pet_auraMap : EntityTypeConfiguration<pet_aura>
    {
        public pet_auraMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.caster_guid, t.item_guid, t.spell });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.caster_guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.item_guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.spell)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
