using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_battleground", Schema="mangos")]

    public partial class creature_battleground
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("event1")] 
		        public byte event1 { get; set; }
 
        [Column("event2")] 
		        public byte event2 { get; set; }
    }
}
