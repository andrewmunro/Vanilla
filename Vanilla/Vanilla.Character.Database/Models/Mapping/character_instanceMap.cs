using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_instanceMap : EntityTypeConfiguration<character_instance>
    {
        public character_instanceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.instance });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.instance)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
