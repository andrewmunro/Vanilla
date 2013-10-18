namespace Vanilla.Database.Login.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class AccountBannedMap : EntityTypeConfiguration<AccountBanned>
    {
        public AccountBannedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.bandate });

            // Properties
            this.Property(t => t.Id)
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
