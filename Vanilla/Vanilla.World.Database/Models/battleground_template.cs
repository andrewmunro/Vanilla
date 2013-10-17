using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("battleground_template", Schema="mangos")]

    public partial class battleground_template
    {
 
        [Column("id")] 
		        public int id { get; set; }
 
        [Column("MinPlayersPerTeam")] 
		        public int MinPlayersPerTeam { get; set; }
 
        [Column("MaxPlayersPerTeam")] 
		        public int MaxPlayersPerTeam { get; set; }
 
        [Column("MinLvl")] 
		        public byte MinLvl { get; set; }
 
        [Column("MaxLvl")] 
		        public byte MaxLvl { get; set; }
 
        [Column("AllianceStartLoc")] 
		        public int AllianceStartLoc { get; set; }
 
        [Column("AllianceStartO")] 
		        public float AllianceStartO { get; set; }
 
        [Column("HordeStartLoc")] 
		        public int HordeStartLoc { get; set; }
 
        [Column("HordeStartO")] 
		        public float HordeStartO { get; set; }
    }
}
