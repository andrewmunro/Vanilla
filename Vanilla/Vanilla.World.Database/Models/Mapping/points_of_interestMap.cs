using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class points_of_interestMap : EntityTypeConfiguration<points_of_interest>
    {
        public points_of_interestMap()
        {
            // Primary Key
            this.HasKey(t => t.entry);

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.icon_name)
                .IsRequired()
                .HasMaxLength(65535);

        }
    }
}
