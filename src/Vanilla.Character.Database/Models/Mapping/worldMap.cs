using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class worldMap : EntityTypeConfiguration<world>
    {
        public worldMap()
        {
            // Primary Key
            this.HasKey(t => t.map);

            // Properties
            this.Property(t => t.map)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.data)
                .HasMaxLength(1073741823);

        }
    }
}
