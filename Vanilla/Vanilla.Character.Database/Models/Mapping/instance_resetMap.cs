using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class instance_resetMap : EntityTypeConfiguration<instance_reset>
    {
        public instance_resetMap()
        {
            // Primary Key
            this.HasKey(t => t.mapid);

            // Properties
            this.Property(t => t.mapid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
