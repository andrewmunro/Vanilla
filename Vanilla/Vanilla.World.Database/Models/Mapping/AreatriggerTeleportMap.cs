using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class AreatriggerTeleportMap : EntityTypeConfiguration<AreatriggerTeleport>
    {
        public AreatriggerTeleportMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(65535);

        }
    }
}
