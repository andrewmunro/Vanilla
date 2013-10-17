using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_gifts", Schema="characters")]

    public partial class character_gifts
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("item_guid")] 
		        public long item_guid { get; set; }
 
        [Column("entry")] 
		        public long entry { get; set; }
 
        [Column("flags")] 
		        public long flags { get; set; }
    }
}
