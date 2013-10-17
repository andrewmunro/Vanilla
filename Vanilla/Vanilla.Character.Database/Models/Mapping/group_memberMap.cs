using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class group_memberMap : EntityTypeConfiguration<group_member>
    {
        public group_memberMap()
        {
            // Primary Key
            this.HasKey(t => new { t.groupId, t.memberGuid });

            // Properties
            this.Property(t => t.groupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.memberGuid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
