using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("dbscripts_on_quest_start", Schema="dbo")]

    public partial class dbscripts_on_quest_start
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("delay")] 
		        public long delay { get; set; }
 
        [Column("command")] 
		        public int command { get; set; }
 
        [Column("datalong")] 
		        public int datalong { get; set; }
 
        [Column("datalong2")] 
		        public long datalong2 { get; set; }
 
        [Column("buddy_entry")] 
		        public int buddy_entry { get; set; }
 
        [Column("search_radius")] 
		        public int search_radius { get; set; }
 
        [Column("data_flags")] 
		        public byte data_flags { get; set; }
 
        [Column("dataint")] 
		        public int dataint { get; set; }
 
        [Column("dataint2")] 
		        public int dataint2 { get; set; }
 
        [Column("dataint3")] 
		        public int dataint3 { get; set; }
 
        [Column("dataint4")] 
		        public int dataint4 { get; set; }
 
        [Column("x")] 
		        public float x { get; set; }
 
        [Column("y")] 
		        public float y { get; set; }
 
        [Column("z")] 
		        public float z { get; set; }
 
        [Column("o")] 
		        public float o { get; set; }
 
        [Column("comments")] 
		        public string comments { get; set; }
    }
}
