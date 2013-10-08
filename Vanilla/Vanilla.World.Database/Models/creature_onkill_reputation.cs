using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.World.Database.Models
{

	    [Table("creature_onkill_reputation", Schema="mangos")]

    public partial class creature_onkill_reputation
    {
 
        [Column("creature_id")] 
		        public int creature_id { get; set; }
 
        [Column("RewOnKillRepFaction1")] 
		        public short RewOnKillRepFaction1 { get; set; }
 
        [Column("RewOnKillRepFaction2")] 
		        public short RewOnKillRepFaction2 { get; set; }
 
        [Column("MaxStanding1")] 
		        public sbyte MaxStanding1 { get; set; }
 
        [Column("IsTeamAward1")] 
		        public sbyte IsTeamAward1 { get; set; }
 
        [Column("RewOnKillRepValue1")] 
		        public int RewOnKillRepValue1 { get; set; }
 
        [Column("MaxStanding2")] 
		        public sbyte MaxStanding2 { get; set; }
 
        [Column("IsTeamAward2")] 
		        public sbyte IsTeamAward2 { get; set; }
 
        [Column("RewOnKillRepValue2")] 
		        public int RewOnKillRepValue2 { get; set; }
 
        [Column("TeamDependent")] 
		        public byte TeamDependent { get; set; }
    }
}
