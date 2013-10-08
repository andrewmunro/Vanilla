using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class areatrigger_involvedrelationMap : EntityTypeConfiguration<AreatriggerInvolvedrelation>
    {
        public areatrigger_involvedrelationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
