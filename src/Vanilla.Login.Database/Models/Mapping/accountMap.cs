using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class accountMap : EntityTypeConfiguration<account>
    {
        public accountMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.username)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.sha_pass_hash)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.sessionkey)
                .HasMaxLength(1073741823);

            this.Property(t => t.v)
                .HasMaxLength(1073741823);

            this.Property(t => t.s)
                .HasMaxLength(1073741823);

            this.Property(t => t.email)
                .HasMaxLength(65535);

            this.Property(t => t.last_ip)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
