namespace Vanilla.Database.World.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class CreatureTemplateMap : EntityTypeConfiguration<CreatureTemplate>
    {
        public CreatureTemplateMap()
        {
            // Primary Key
            this.HasKey(t => t.Entry);

            // Properties
            this.Property(t => t.Entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Subname)
                .HasMaxLength(100);

            this.Property(t => t.AIName)
                .HasMaxLength(64);

            this.Property(t => t.ScriptName)
                .HasMaxLength(64);

        }
    }
}
