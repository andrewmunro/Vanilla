using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature_linking", Schema="mangos")]

    public partial class creature_linking
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("master_guid")] 
		        public long master_guid { get; set; }
 
        [Column("flag")] 
		        public int flag { get; set; }
    }
}
