using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class characterMap : EntityTypeConfiguration<character>
    {
        public characterMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.taximask)
                .HasMaxLength(1073741823);

            this.Property(t => t.taxi_path)
                .HasMaxLength(65535);

            this.Property(t => t.exploredZones)
                .HasMaxLength(1073741823);

            this.Property(t => t.equipmentCache)
                .HasMaxLength(1073741823);

            this.Property(t => t.deleteInfos_Name)
                .HasMaxLength(12);

        }
    }
}
