using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class groupMap : EntityTypeConfiguration<group>
    {
        public groupMap()
        {
            // Primary Key
            this.HasKey(t => t.groupId);

            // Properties
            this.Property(t => t.groupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
