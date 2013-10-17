using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("world", Schema="characters")]

    public partial class world
    {
 
        [Column("map")] 
		        public long map { get; set; }
 
        [Column("data")] 
		        public string data { get; set; }
    }
}
