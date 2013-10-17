using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class petitionMap : EntityTypeConfiguration<petition>
    {
        public petitionMap()
        {
            // Primary Key
            this.HasKey(t => t.ownerguid);

            // Properties
            this.Property(t => t.ownerguid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
