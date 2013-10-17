using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class CharacterMap : EntityTypeConfiguration<Character>
    {
        public CharacterMap()
        {
            // Primary Key
            this.HasKey(t => t.GUID);

            // Properties
            this.Property(t => t.GUID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(12);

            this.Property(t => t.TaxiMask)
                .HasMaxLength(1073741823);

            this.Property(t => t.TaxiPath)
                .HasMaxLength(65535);

            this.Property(t => t.ExploredZones)
                .HasMaxLength(1073741823);

            this.Property(t => t.EquipmentCache)
                .HasMaxLength(1073741823);

            this.Property(t => t.DeleteInfosName)
                .HasMaxLength(12);

        }
    }
}
