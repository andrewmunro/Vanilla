using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Vanilla.Database.Character.Models.Mapping
{
    public class character_ticketMap : EntityTypeConfiguration<character_ticket>
    {
        public character_ticketMap()
        {
            // Primary Key
            this.HasKey(t => t.ticket_id);

            // Properties
            this.Property(t => t.ticket_text)
                .HasMaxLength(65535);

            this.Property(t => t.response_text)
                .HasMaxLength(65535);

        }
    }
}
