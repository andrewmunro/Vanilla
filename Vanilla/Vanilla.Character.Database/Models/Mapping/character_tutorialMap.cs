using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Character.Database.Models.Mapping
{
    public class character_tutorialMap : EntityTypeConfiguration<character_tutorial>
    {
        public character_tutorialMap()
        {
            // Primary Key
            this.HasKey(t => t.account);

            // Properties
        }
    }
}
