namespace Vanilla.Database.World.Models.Mapping
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class GameEventQuestMap : EntityTypeConfiguration<GameEventQuest>
    {
        public GameEventQuestMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Quest, t.Event });

            // Properties
            this.Property(t => t.Quest)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Event)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
