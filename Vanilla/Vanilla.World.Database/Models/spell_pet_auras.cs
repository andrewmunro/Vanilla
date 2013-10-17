using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_pet_auras", Schema="mangos")]

    public partial class spell_pet_auras
    {
 
        [Column("spell")] 
		        public int spell { get; set; }
 
        [Column("pet")] 
		        public int pet { get; set; }
 
        [Column("aura")] 
		        public int aura { get; set; }
    }
}
