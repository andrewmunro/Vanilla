using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("instance_template", Schema="mangos")]

    public partial class instance_template
    {
 
        [Column("map")] 
		        public int map { get; set; }
 
        [Column("parent")] 
		        public int parent { get; set; }
 
        [Column("levelMin")] 
		        public byte levelMin { get; set; }
 
        [Column("levelMax")] 
		        public byte levelMax { get; set; }
 
        [Column("maxPlayers")] 
		        public byte maxPlayers { get; set; }
 
        [Column("reset_delay")] 
		        public long reset_delay { get; set; }
 
        [Column("ghostEntranceMap")] 
		        public int ghostEntranceMap { get; set; }
 
        [Column("ghostEntranceX")] 
		        public float ghostEntranceX { get; set; }
 
        [Column("ghostEntranceY")] 
		        public float ghostEntranceY { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
