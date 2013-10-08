using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
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
