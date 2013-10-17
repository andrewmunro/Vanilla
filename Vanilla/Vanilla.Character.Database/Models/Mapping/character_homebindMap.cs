using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Vanilla.Database.Character.Models;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_homebindMap : EntityTypeConfiguration<character_homebind>
    {
        public character_homebindMap()
        {
            // Primary Key
            this.HasKey(t => t.guid);

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
