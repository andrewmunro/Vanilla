using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class exploration_basexpMap : EntityTypeConfiguration<exploration_basexp>
    {
        public exploration_basexpMap()
        {
            // Primary Key
            this.HasKey(t => t.level);

            // Properties
        }
    }
}
