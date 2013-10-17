using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class guild_memberMap : EntityTypeConfiguration<guild_member>
    {
        public guild_memberMap()
        {
            // Primary Key
            this.HasKey(t => new { t.guildid, t.guid, t.rank, t.pnote, t.offnote });

            // Properties
            this.Property(t => t.guildid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.guid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pnote)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.offnote)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
