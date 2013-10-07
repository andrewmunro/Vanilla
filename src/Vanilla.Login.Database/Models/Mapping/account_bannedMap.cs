using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class account_bannedMap : EntityTypeConfiguration<account_banned>
    {
        public account_bannedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.bandate });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

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
