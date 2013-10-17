using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("scripted_event", Schema="mangos")]

    public partial class scripted_event
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
