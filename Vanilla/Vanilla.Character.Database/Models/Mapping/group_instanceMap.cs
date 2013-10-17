using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class group_instanceMap : EntityTypeConfiguration<group_instance>
    {
        public group_instanceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.leaderGuid, t.instance });

            // Properties
            this.Property(t => t.leaderGuid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.instance)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
