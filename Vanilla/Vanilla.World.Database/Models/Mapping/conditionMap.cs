using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class conditionMap : EntityTypeConfiguration<condition>
    {
        public conditionMap()
        {
            // Primary Key
            this.HasKey(t => t.condition_entry);

            // Properties
        }
    }
}
