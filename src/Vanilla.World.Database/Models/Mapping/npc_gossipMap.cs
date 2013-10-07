using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class npc_gossipMap : EntityTypeConfiguration<npc_gossip>
    {
        public npc_gossipMap()
        {
            // Primary Key
            this.HasKey(t => t.npc_guid);

            // Properties
            this.Property(t => t.npc_guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
