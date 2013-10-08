using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class pool_poolMap : EntityTypeConfiguration<pool_pool>
    {
        public pool_poolMap()
        {
            // Primary Key
            this.HasKey(t => t.pool_id);

            // Properties
            this.Property(t => t.pool_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
