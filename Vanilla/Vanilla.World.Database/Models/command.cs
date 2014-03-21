using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("command", Schema="dbo")]

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
