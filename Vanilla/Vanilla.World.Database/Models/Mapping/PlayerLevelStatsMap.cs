namespace Vanilla.Database.World.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class PlayerLevelStatsMap : EntityTypeConfiguration<PlayerLevelStats>
    {
        public PlayerLevelStatsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Race, t.Class, t.Level });

            // Properties
        }
    }
}
