using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("spell_proc_event", Schema="dbo")]

    public partial class spell_proc_event
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("SchoolMask")] 
		        public byte SchoolMask { get; set; }
 
        [Column("SpellFamilyName")] 
		        public int SpellFamilyName { get; set; }
 
        [Column("SpellFamilyMask0")] 
		        public long SpellFamilyMask0 { get; set; }
 
        [Column("SpellFamilyMask1")] 
		        public long SpellFamilyMask1 { get; set; }
 
        [Column("SpellFamilyMask2")] 
		        public long SpellFamilyMask2 { get; set; }
 
        [Column("procFlags")] 
		        public long procFlags { get; set; }
 
        [Column("procEx")] 
		        public long procEx { get; set; }
 
        [Column("ppmRate")] 
		        public float ppmRate { get; set; }
 
        [Column("CustomChance")] 
		        public float CustomChance { get; set; }
 
        [Column("Cooldown")] 
		        public long Cooldown { get; set; }
    }
}
