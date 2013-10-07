using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("game_event_mail", Schema="mangos")]

    public partial class game_event_mail
    {
 
        [Column("event")] 
		        public short @event { get; set; }
 
        [Column("raceMask")] 
		        public int raceMask { get; set; }
 
        [Column("quest")] 
		        public int quest { get; set; }
 
        [Column("mailTemplateId")] 
		        public int mailTemplateId { get; set; }
 
        [Column("senderEntry")] 
		        public int senderEntry { get; set; }
    }
}
