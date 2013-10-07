using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("battleground_events", Schema="mangos")]

    public partial class battleground_events
    {
 
        [Column("map")] 
		        public short map { get; set; }
 
        [Column("event1")] 
		        public byte event1 { get; set; }
 
        [Column("event2")] 
		        public byte event2 { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
    }
}
