using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_action", Schema="characters")]

    public partial class character_action
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("button")] 
		        public byte button { get; set; }
 
        [Column("action")] 
		        public long action { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
    }
}
