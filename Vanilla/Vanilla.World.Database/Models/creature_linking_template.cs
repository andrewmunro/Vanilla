using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_linking_template", Schema="dbo")]

    public partial class creature_linking_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("master_entry")] 
		        public int master_entry { get; set; }
 
        [Column("flag")] 
		        public int flag { get; set; }
 
        [Column("search_range")] 
		        public int search_range { get; set; }
    }
}
