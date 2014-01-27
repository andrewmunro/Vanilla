using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.World.Models.Mapping
{
    public class item_templateMap : EntityTypeConfiguration<ItemTemplate>
    {
        public item_templateMap()
        {
            // Primary Key
            this.HasKey(t => t.Entry);

            // Properties
            this.Property(t => t.Entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.description)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.ScriptName)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
