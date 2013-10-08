using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("gameobject_loot_template", Schema="mangos")]

    public partial class gameobject_loot_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("item")] 
		        public int item { get; set; }
 
        [Column("ChanceOrQuestChance")] 
		        public float ChanceOrQuestChance { get; set; }
 
        [Column("groupid")] 
		        public byte groupid { get; set; }
 
        [Column("mincountOrRef")] 
		        public int mincountOrRef { get; set; }
 
        [Column("maxcount")] 
		        public byte maxcount { get; set; }
 
        [Column("condition_id")] 
		        public int condition_id { get; set; }
    }
}
