using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class petition_signMap : EntityTypeConfiguration<petition_sign>
    {
        public petition_signMap()
        {
            // Primary Key
            this.HasKey(t => new { t.petitionguid, t.playerguid });

            // Properties
            this.Property(t => t.petitionguid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.playerguid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
