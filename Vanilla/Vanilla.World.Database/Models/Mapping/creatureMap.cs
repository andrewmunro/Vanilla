namespace Vanilla.Database.World.Models.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class CreatureMap : EntityTypeConfiguration<Creature>
    {
        public CreatureMap()
        {
            // Primary Key
            this.HasKey(t => t.GUID);

            // Properties
        }
    }
}
