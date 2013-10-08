using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class spell_linkedMap : EntityTypeConfiguration<spell_linked>
    {
        public spell_linkedMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.linked_entry, t.type });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.linked_entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.type)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.comment)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
