using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class guild_rankMap : EntityTypeConfiguration<guild_rank>
    {
        public guild_rankMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guildid, t.rid });

            // Properties
            this.Property(t => t.guildid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.rname)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
