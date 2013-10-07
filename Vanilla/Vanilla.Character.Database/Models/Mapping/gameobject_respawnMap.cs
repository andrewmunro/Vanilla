using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class gameobject_respawnMap : EntityTypeConfiguration<gameobject_respawn>
    {
        public gameobject_respawnMap()
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
