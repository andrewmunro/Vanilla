using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("points_of_interest", Schema="mangos")]

    public partial class points_of_interest
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("x")] 
		        public float x { get; set; }
 
        [Column("y")] 
		        public float y { get; set; }
 
        [Column("icon")] 
		        public int icon { get; set; }
 
        [Column("flags")] 
		        public int flags { get; set; }
 
        [Column("data")] 
		        public int data { get; set; }
 
        [Column("icon_name")] 
		        public string icon_name { get; set; }
    }
}
