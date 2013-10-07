using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class character_honor_cpMap : EntityTypeConfiguration<character_honor_cp>
    {
        public character_honor_cpMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guid, t.victim_type, t.victim, t.honor, t.date, t.type });

            // Properties
            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.victim)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.date)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
