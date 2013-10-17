using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class item_required_targetMap : EntityTypeConfiguration<item_required_target>
    {
        public item_required_targetMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.type, t.targetEntry });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.targetEntry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
