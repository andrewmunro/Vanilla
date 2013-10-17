using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class guildMap : EntityTypeConfiguration<guild>
    {
        public guildMap()
        {
            // Primary Key
            this.HasKey(t => t.guildid);

            // Properties
            this.Property(t => t.guildid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.info)
                .IsRequired()
                .HasMaxLength(65535);

            this.Property(t => t.motd)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
