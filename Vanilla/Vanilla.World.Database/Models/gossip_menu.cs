using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("gossip_menu", Schema="dbo")]

    public partial class gossip_menu
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("text_id")] 
		        public int text_id { get; set; }
 
        [Column("script_id")] 
		        public int script_id { get; set; }
 
        [Column("condition_id")] 
		        public int condition_id { get; set; }
    }
}
