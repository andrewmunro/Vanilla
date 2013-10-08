using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.World.Database.Models.Mapping
{
    public class creature_model_infoMap : EntityTypeConfiguration<creature_model_info>
    {
        public creature_model_infoMap()
        {
            // Primary Key
            this.HasKey(t => t.modelid);

            // Properties
            this.Property(t => t.modelid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
