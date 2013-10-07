using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Character.Database.Models
{

	    [Table("character_spell", Schema="characters")]

    public partial class character_spell
    {
 
        [Column("guid")] 
		        public long guid { get; set; }
 
        [Column("spell")] 
		        public long spell { get; set; }
 
        [Column("active")] 
		        public byte active { get; set; }
 
        [Column("disabled")] 
		        public byte disabled { get; set; }
    }
}
