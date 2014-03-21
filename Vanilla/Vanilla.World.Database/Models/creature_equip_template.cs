using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("creature_equip_template", Schema="dbo")]

    public partial class creature_equip_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("equipentry1")] 
		        public int equipentry1 { get; set; }
 
        [Column("equipentry2")] 
		        public int equipentry2 { get; set; }
 
        [Column("equipentry3")] 
		        public int equipentry3 { get; set; }
    }
}
