using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_tutorial", Schema="characters")]

    public partial class character_tutorial
    {
 
        [Column("account")] 
		        public decimal account { get; set; }
 
        [Column("tut0")] 
		        public long tut0 { get; set; }
 
        [Column("tut1")] 
		        public long tut1 { get; set; }
 
        [Column("tut2")] 
		        public long tut2 { get; set; }
 
        [Column("tut3")] 
		        public long tut3 { get; set; }
 
        [Column("tut4")] 
		        public long tut4 { get; set; }
 
        [Column("tut5")] 
		        public long tut5 { get; set; }
 
        [Column("tut6")] 
		        public long tut6 { get; set; }
 
        [Column("tut7")] 
		        public long tut7 { get; set; }
    }
}
