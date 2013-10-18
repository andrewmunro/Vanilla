namespace Vanilla.Database.Login.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class RealmCharacterMap : EntityTypeConfiguration<RealmCharacter>
    {
        public RealmCharacterMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RealmId, t.AccountID });

            // Properties
            this.Property(t => t.RealmId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AccountID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
