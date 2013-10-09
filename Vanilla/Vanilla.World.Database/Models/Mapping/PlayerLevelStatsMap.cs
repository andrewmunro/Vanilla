namespace Vanilla.World.Database.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class PlayerLevelStatsMap : EntityTypeConfiguration<PlayerLevelStats>
    {
        public PlayerLevelStatsMap()
        {
            // Primary Key
            this.HasKey(t => new { race = t.Race, t.Class, level = t.Level });

            // Properties
        }
    }
}
