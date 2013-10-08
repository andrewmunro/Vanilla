using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("battlemaster_entry", Schema="mangos")]

    public partial class battlemaster_entry
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("bg_template")] 
		        public int bg_template { get; set; }
    }
}
