using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("page_text", Schema="mangos")]

    public partial class page_text
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("text")] 
		        public string text { get; set; }
 
        [Column("next_page")] 
		        public int next_page { get; set; }
    }
}
