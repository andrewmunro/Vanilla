using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class spell_chainMap : EntityTypeConfiguration<spell_chain>
    {
        public spell_chainMap()
        {
            // Primary Key
            this.HasKey(t => t.spell_id);

            // Properties
            this.Property(t => t.spell_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
