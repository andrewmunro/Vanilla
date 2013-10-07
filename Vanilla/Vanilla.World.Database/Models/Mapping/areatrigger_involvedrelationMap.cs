using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class areatrigger_involvedrelationMap : EntityTypeConfiguration<areatrigger_involvedrelation>
    {
        public areatrigger_involvedrelationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
