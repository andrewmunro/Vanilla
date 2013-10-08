using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("player_classlevelstats", Schema="mangos")]

    public partial class player_classlevelstats
    {
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("level")] 
		        public byte level { get; set; }
 
        [Column("basehp")] 
		        public int basehp { get; set; }
 
        [Column("basemana")] 
		        public int basemana { get; set; }
    }
}
