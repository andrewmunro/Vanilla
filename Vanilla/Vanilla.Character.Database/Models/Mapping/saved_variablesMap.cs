using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class saved_variablesMap : EntityTypeConfiguration<saved_variables>
    {
        public saved_variablesMap()
        {
            // Primary Key
            this.HasKey(t => new { t.NextMaintenanceDate, t.cleaning_flags });

            // Properties
            this.Property(t => t.NextMaintenanceDate)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.cleaning_flags)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
