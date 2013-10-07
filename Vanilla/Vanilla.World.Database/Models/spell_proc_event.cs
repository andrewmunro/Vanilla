using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("spell_proc_event", Schema="mangos")]

    public partial class spell_proc_event
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("SchoolMask")] 
		        public byte SchoolMask { get; set; }
 
        [Column("SpellFamilyName")] 
		        public int SpellFamilyName { get; set; }
 
        [Column("SpellFamilyMask0")] 
		        public decimal SpellFamilyMask0 { get; set; }
 
        [Column("SpellFamilyMask1")] 
		        public decimal SpellFamilyMask1 { get; set; }
 
        [Column("SpellFamilyMask2")] 
		        public decimal SpellFamilyMask2 { get; set; }
 
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
