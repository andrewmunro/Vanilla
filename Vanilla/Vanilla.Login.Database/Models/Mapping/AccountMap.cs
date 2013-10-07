using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ShaPassHash)
                .IsRequired()
                .HasMaxLength(40);

            this.Property(t => t.SessionKey)
                .HasMaxLength(1073741823);

            this.Property(t => t.V)
                .HasMaxLength(1073741823);

            this.Property(t => t.S)
                .HasMaxLength(1073741823);

            this.Property(t => t.Email)
                .HasMaxLength(65535);

            this.Property(t => t.LastIP)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}
