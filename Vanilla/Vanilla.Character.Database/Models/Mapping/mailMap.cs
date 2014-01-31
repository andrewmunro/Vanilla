using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class MailMap : EntityTypeConfiguration<Mail>
    {
        public MailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Subject)
                .HasMaxLength(1073741823);

        }
    }
}
