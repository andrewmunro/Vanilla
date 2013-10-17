using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_ticket", Schema="characters")]

    public partial class character_ticket
    {
 
        [Column("ticket_id")] 
		        public long ticket_id { get; set; }
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("ticket_text")] 
		        public string ticket_text { get; set; }
 
        [Column("response_text")] 
		        public string response_text { get; set; }
 
        [Column("ticket_lastchange")] 
		        public System.DateTime ticket_lastchange { get; set; }
    }
}
