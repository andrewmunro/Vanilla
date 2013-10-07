using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class ip_bannedMap : EntityTypeConfiguration<ip_banned>
    {
        public ip_bannedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ip, t.bandate });

            // Properties
            this.Property(t => t.ip)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.bandate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.bannedby)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.banreason)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
