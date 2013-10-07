using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class pool_creatureMap : EntityTypeConfiguration<pool_creature>
    {
        public pool_creatureMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
