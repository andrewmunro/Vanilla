using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("skill_fishing_base_level", Schema="mangos")]

    public partial class skill_fishing_base_level
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("skill")] 
		        public short skill { get; set; }
    }
}
