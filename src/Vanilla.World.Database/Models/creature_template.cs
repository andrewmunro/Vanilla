using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace VanillaDB.Models
{

	    [Table("creature_template", Schema="mangos")]

    public partial class creature_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("KillCredit1")] 
		        public long KillCredit1 { get; set; }
 
        [Column("KillCredit2")] 
		        public long KillCredit2 { get; set; }
 
        [Column("modelid_1")] 
		        public int modelid_1 { get; set; }
 
        [Column("modelid_2")] 
		        public int modelid_2 { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("subname")] 
		        public string subname { get; set; }
 
        [Column("gossip_menu_id")] 
		        public int gossip_menu_id { get; set; }
 
        [Column("minlevel")] 
		        public byte minlevel { get; set; }
 
        [Column("maxlevel")] 
		        public byte maxlevel { get; set; }
 
        [Column("minhealth")] 
		        public long minhealth { get; set; }
 
        [Column("maxhealth")] 
		        public long maxhealth { get; set; }
 
        [Column("minmana")] 
		        public long minmana { get; set; }
 
        [Column("maxmana")] 
		        public long maxmana { get; set; }
 
        [Column("armor")] 
		        public int armor { get; set; }
 
        [Column("faction_A")] 
		        public int faction_A { get; set; }
 
        [Column("faction_H")] 
		        public int faction_H { get; set; }
 
        [Column("npcflag")] 
		        public long npcflag { get; set; }
 
        [Column("speed_walk")] 
		        public float speed_walk { get; set; }
 
        [Column("speed_run")] 
		        public float speed_run { get; set; }
 
        [Column("scale")] 
		        public float scale { get; set; }
 
        [Column("rank")] 
		        public byte rank { get; set; }
 
        [Column("mindmg")] 
		        public float mindmg { get; set; }
 
        [Column("maxdmg")] 
		        public float maxdmg { get; set; }
 
        [Column("dmgschool")] 
		        public sbyte dmgschool { get; set; }
 
        [Column("attackpower")] 
		        public long attackpower { get; set; }
 
        [Column("dmg_multiplier")] 
		        public float dmg_multiplier { get; set; }
 
        [Column("baseattacktime")] 
		        public long baseattacktime { get; set; }
 
        [Column("rangeattacktime")] 
		        public long rangeattacktime { get; set; }
 
        [Column("unit_class")] 
		        public byte unit_class { get; set; }
 
        [Column("unit_flags")] 
		        public long unit_flags { get; set; }
 
        [Column("dynamicflags")] 
		        public long dynamicflags { get; set; }
 
        [Column("family")] 
		        public sbyte family { get; set; }
 
        [Column("trainer_type")] 
		        public sbyte trainer_type { get; set; }
 
        [Column("trainer_spell")] 
		        public int trainer_spell { get; set; }
 
        [Column("trainer_class")] 
		        public byte trainer_class { get; set; }
 
        [Column("trainer_race")] 
		        public byte trainer_race { get; set; }
 
        [Column("minrangedmg")] 
		        public float minrangedmg { get; set; }
 
        [Column("maxrangedmg")] 
		        public float maxrangedmg { get; set; }
 
        [Column("rangedattackpower")] 
		        public int rangedattackpower { get; set; }
 
        [Column("type")] 
		        public byte type { get; set; }
 
        [Column("type_flags")] 
		        public long type_flags { get; set; }
 
        [Column("lootid")] 
		        public int lootid { get; set; }
 
        [Column("pickpocketloot")] 
		        public int pickpocketloot { get; set; }
 
        [Column("skinloot")] 
		        public int skinloot { get; set; }
 
        [Column("resistance1")] 
		        public short resistance1 { get; set; }
 
        [Column("resistance2")] 
		        public short resistance2 { get; set; }
 
        [Column("resistance3")] 
		        public short resistance3 { get; set; }
 
        [Column("resistance4")] 
		        public short resistance4 { get; set; }
 
        [Column("resistance5")] 
		        public short resistance5 { get; set; }
 
        [Column("resistance6")] 
		        public short resistance6 { get; set; }
 
        [Column("PetSpellDataId")] 
		        public int PetSpellDataId { get; set; }
 
        [Column("mingold")] 
		        public int mingold { get; set; }
 
        [Column("maxgold")] 
		        public int maxgold { get; set; }
 
        [Column("AIName")] 
		        public string AIName { get; set; }
 
        [Column("MovementType")] 
		        public Nullable<byte> MovementType { get; set; }
 
        [Column("InhabitType")] 
		        public byte InhabitType { get; set; }
 
        [Column("Civilian")] 
		        public byte Civilian { get; set; }
 
        [Column("RacialLeader")] 
		        public byte RacialLeader { get; set; }
 
        [Column("RegenHealth")] 
		        public byte RegenHealth { get; set; }
 
        [Column("equipment_id")] 
		        public int equipment_id { get; set; }
 
        [Column("trainer_id")] 
		        public int trainer_id { get; set; }
 
        [Column("vendor_id")] 
		        public int vendor_id { get; set; }
 
        [Column("mechanic_immune_mask")] 
		        public long mechanic_immune_mask { get; set; }
 
        [Column("flags_extra")] 
		        public long flags_extra { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
    }
}
