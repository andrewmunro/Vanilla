using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_skills", Schema="characters")]

    public partial class character_skills
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("skill")] 
		        public int skill { get; set; }
 
        [Column("value")] 
		        public int value { get; set; }
 
        [Column("max")] 
		        public int max { get; set; }
    }
}
