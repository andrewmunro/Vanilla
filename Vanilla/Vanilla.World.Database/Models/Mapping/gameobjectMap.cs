namespace Vanilla.Database.World.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class GameObjectMap : EntityTypeConfiguration<GameObject>
    {
        public GameObjectMap()
        {
            // Primary Key
            this.HasKey(t => t.GUID);

            // Properties
        }
    }
}
