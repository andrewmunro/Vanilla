using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VanillaDB.Models.Mapping
{
    public class npc_vendorMap : EntityTypeConfiguration<npc_vendor>
    {
        public npc_vendorMap()
        {
            // Primary Key
            this.HasKey(t => new { t.entry, t.item });

            // Properties
            this.Property(t => t.entry)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.item)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

        }
    }
}
