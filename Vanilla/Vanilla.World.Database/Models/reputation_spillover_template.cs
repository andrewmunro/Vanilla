using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("reputation_spillover_template", Schema="mangos")]

    public partial class reputation_spillover_template
    {
 
        [Column("faction")] 
		        public int faction { get; set; }
 
        [Column("faction1")] 
		        public int faction1 { get; set; }
 
        [Column("rate_1")] 
		        public float rate_1 { get; set; }
 
        [Column("rank_1")] 
		        public byte rank_1 { get; set; }
 
        [Column("faction2")] 
		        public int faction2 { get; set; }
 
        [Column("rate_2")] 
		        public float rate_2 { get; set; }
 
        [Column("rank_2")] 
		        public byte rank_2 { get; set; }
 
        [Column("faction3")] 
		        public int faction3 { get; set; }
 
        [Column("rate_3")] 
		        public float rate_3 { get; set; }
 
        [Column("rank_3")] 
		        public byte rank_3 { get; set; }
 
        [Column("faction4")] 
		        public int faction4 { get; set; }
 
        [Column("rate_4")] 
		        public float rate_4 { get; set; }
 
        [Column("rank_4")] 
		        public byte rank_4 { get; set; }
    }
}
