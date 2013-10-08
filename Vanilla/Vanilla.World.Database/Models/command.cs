using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("command", Schema="mangos")]

    public partial class command
    {
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("security")] 
		        public byte security { get; set; }
 
        [Column("help")] 
		        public string help { get; set; }
    }
}
