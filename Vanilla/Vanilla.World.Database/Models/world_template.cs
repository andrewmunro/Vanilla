using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("world_template", Schema="dbo")]

    public partial class world_template
    {
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
