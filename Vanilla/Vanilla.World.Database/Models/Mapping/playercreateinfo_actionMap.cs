using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class playercreateinfo_actionMap : EntityTypeConfiguration<playercreateinfo_action>
    {
        public playercreateinfo_actionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.race, t.class, t.button });

            // Properties
            this.Property(t => t.button)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
