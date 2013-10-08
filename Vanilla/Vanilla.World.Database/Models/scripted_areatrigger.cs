using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("scripted_areatrigger", Schema="mangos")]

    public partial class scripted_areatrigger
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
