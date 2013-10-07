using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Login.Database.Models.Mapping
{
    public class realmlistMap : EntityTypeConfiguration<realmlist>
    {
        public realmlistMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.address)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.realmbuilds)
                .IsRequired()
                .HasMaxLength(64);

        }
    }
}
