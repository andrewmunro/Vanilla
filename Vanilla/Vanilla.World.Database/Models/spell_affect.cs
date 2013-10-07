using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_affect", Schema="mangos")]

    public partial class spell_affect
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("effectId")] 
		        public byte effectId { get; set; }
 
        [Column("SpellFamilyMask")] 
		        public decimal SpellFamilyMask { get; set; }
    }
}
