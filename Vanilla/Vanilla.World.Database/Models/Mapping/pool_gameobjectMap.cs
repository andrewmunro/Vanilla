using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class pool_gameobjectMap : EntityTypeConfiguration<pool_gameobject>
    {
        public pool_gameobjectMap()
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
