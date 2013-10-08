using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("player_levelstats", Schema="mangos")]

    public partial class player_levelstats
    {
 
        [Column("race")] 
		        public byte race { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("level")] 
		        public byte level { get; set; }
 
        [Column("str")] 
		        public byte str { get; set; }
 
        [Column("agi")] 
		        public byte agi { get; set; }
 
        [Column("sta")] 
		        public byte sta { get; set; }
 
        [Column("inte")] 
		        public byte inte { get; set; }
 
        [Column("spi")] 
		        public byte spi { get; set; }
    }
}
