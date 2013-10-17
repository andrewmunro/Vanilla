using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("reputation_reward_rate", Schema="mangos")]

    public partial class reputation_reward_rate
    {
 
        [Column("faction")] 
		        public int faction { get; set; }
 
        [Column("quest_rate")] 
		        public float quest_rate { get; set; }
 
        [Column("creature_rate")] 
		        public float creature_rate { get; set; }
 
        [Column("spell_rate")] 
		        public float spell_rate { get; set; }
    }
}
