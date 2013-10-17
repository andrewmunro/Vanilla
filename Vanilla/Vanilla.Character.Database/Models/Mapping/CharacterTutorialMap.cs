namespace Vanilla.Database.Character.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CharacterTutorialMap : EntityTypeConfiguration<CharacterTutorial>
    {
        public CharacterTutorialMap()
        {
            // Primary Key
            this.HasKey(t => t.Account);

            // Properties
        }
    }
}
