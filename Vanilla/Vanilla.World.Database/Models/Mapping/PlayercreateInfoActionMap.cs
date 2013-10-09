namespace Vanilla.World.Database.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class PlayercreateInfoActionMap : EntityTypeConfiguration<PlayerCreateInfoAction>
    {
        public PlayercreateInfoActionMap()
        {
            // Primary Key
            this.HasKey(t => new { race = t.Race, t.Class, button = t.Button });

            // Properties
            this.Property(t => t.Button)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
