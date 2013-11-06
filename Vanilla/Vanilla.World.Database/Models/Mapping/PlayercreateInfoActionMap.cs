namespace Vanilla.Database.World.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class PlayercreateInfoActionMap : EntityTypeConfiguration<PlayerCreateInfoAction>
    {
        public PlayercreateInfoActionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Race, t.Class, t.Button });

            // Properties
            this.Property(t => t.Button)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
