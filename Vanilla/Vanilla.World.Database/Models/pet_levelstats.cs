using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("pet_levelstats", Schema="mangos")]

    public partial class pet_levelstats
    {
 
        [Column("creature_entry")] 
		        public int creature_entry { get; set; }
 
        [Column("level")] 
		        public byte level { get; set; }
 
        [Column("hp")] 
		        public int hp { get; set; }
 
        [Column("mana")] 
		        public int mana { get; set; }
 
        [Column("armor")] 
		        public long armor { get; set; }
 
        [Column("str")] 
		        public int str { get; set; }
 
        [Column("agi")] 
		        public int agi { get; set; }
 
        [Column("sta")] 
		        public int sta { get; set; }
 
        [Column("inte")] 
		        public int inte { get; set; }
 
        [Column("spi")] 
		        public int spi { get; set; }
    }
}
