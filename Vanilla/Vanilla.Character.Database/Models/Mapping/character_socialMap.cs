using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_socialMap : EntityTypeConfiguration<character_social>
    {
        public character_socialMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.friend, t.flags });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.friend)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
