using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.Character.Models
{

	    [Table("character_stats", Schema="characters")]

    public partial class character_stats
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("maxhealth")] 
		        public long maxhealth { get; set; }
 
        [Column("maxpower1")] 
		        public long maxpower1 { get; set; }
 
        [Column("maxpower2")] 
		        public long maxpower2 { get; set; }
 
        [Column("maxpower3")] 
		        public long maxpower3 { get; set; }
 
        [Column("maxpower4")] 
		        public long maxpower4 { get; set; }
 
        [Column("maxpower5")] 
		        public long maxpower5 { get; set; }
 
        [Column("maxpower6")] 
		        public long maxpower6 { get; set; }
 
        [Column("maxpower7")] 
		        public long maxpower7 { get; set; }
 
        [Column("strength")] 
		        public long strength { get; set; }
 
        [Column("agility")] 
		        public long agility { get; set; }
 
        [Column("stamina")] 
		        public long stamina { get; set; }
 
        [Column("intellect")] 
		        public long intellect { get; set; }
 
        [Column("spirit")] 
		        public long spirit { get; set; }
 
        [Column("armor")] 
		        public long armor { get; set; }
 
        [Column("resHoly")] 
		        public long resHoly { get; set; }
 
        [Column("resFire")] 
		        public long resFire { get; set; }
 
        [Column("resNature")] 
		        public long resNature { get; set; }
 
        [Column("resFrost")] 
		        public long resFrost { get; set; }
 
        [Column("resShadow")] 
		        public long resShadow { get; set; }
 
        [Column("resArcane")] 
		        public long resArcane { get; set; }
 
        [Column("attackPower")] 
		        public long attackPower { get; set; }
 
        [Column("rangedAttackPower")] 
		        public long rangedAttackPower { get; set; }
    }
}
