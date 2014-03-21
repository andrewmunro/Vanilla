using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_affect", Schema="dbo")]

    public partial class spell_affect
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("effectId")] 
		        public byte effectId { get; set; }
 
        [Column("SpellFamilyMask")] 
		        public long SpellFamilyMask { get; set; }
    }
}
