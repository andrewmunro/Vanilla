namespace Vanilla.Database.World.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("creature_template", Schema="dbo")]
    public class CreatureTemplate
    {
 
        [Column("entry")] 
                public int Entry { get; set; }
 
        [Column("KillCredit1")] 
                public long KillCredit1 { get; set; }
 
        [Column("KillCredit2")] 
                public long KillCredit2 { get; set; }
 
        [Column("modelid_1")] 
                public int Modelid1 { get; set; }
 
        [Column("modelid_2")] 
                public int Modelid2 { get; set; }
 
        [Column("name")] 
                public string Name { get; set; }
 
        [Column("subname")] 
                public string Subname { get; set; }
 
        [Column("gossip_menu_id")] 
                public int GossipMenuID { get; set; }
 
        [Column("minlevel")] 
                public byte Minlevel { get; set; }
 
        [Column("maxlevel")] 
                public byte Maxlevel { get; set; }
 
        [Column("minhealth")] 
                public long Minhealth { get; set; }
 
        [Column("maxhealth")] 
                public long Maxhealth { get; set; }
 
        [Column("minmana")] 
                public long Minmana { get; set; }
 
        [Column("maxmana")] 
                public long Maxmana { get; set; }
 
        [Column("armor")] 
                public int Armor { get; set; }
 
        [Column("faction_A")] 
                public int FactionA { get; set; }
 
        [Column("faction_H")] 
                public int FactionH { get; set; }
 
        [Column("npcflag")] 
                public long Npcflag { get; set; }
 
        [Column("speed_walk")] 
                public float SpeedWalk { get; set; }
 
        [Column("speed_run")] 
                public float SpeedRun { get; set; }
 
        [Column("scale")] 
                public float Scale { get; set; }
 
        [Column("rank")] 
                public byte Rank { get; set; }
 
        [Column("mindmg")] 
                public float Mindmg { get; set; }
 
        [Column("maxdmg")] 
                public float Maxdmg { get; set; }
 
        [Column("dmgschool")] 
                public byte Dmgschool { get; set; }
 
        [Column("attackpower")] 
                public long Attackpower { get; set; }
 
        [Column("dmg_multiplier")] 
                public float DmgMultiplier { get; set; }
 
        [Column("baseattacktime")] 
                public long Baseattacktime { get; set; }
 
        [Column("rangeattacktime")] 
                public long Rangeattacktime { get; set; }
 
        [Column("unit_class")] 
                public byte UnitClass { get; set; }
 
        [Column("unit_flags")] 
                public long UnitFlags { get; set; }
 
        [Column("dynamicflags")] 
                public long Dynamicflags { get; set; }
 
        [Column("family")] 
                public byte Family { get; set; }
 
        [Column("trainer_type")] 
                public byte TrainerType { get; set; }
 
        [Column("trainer_spell")] 
                public int TrainerSpell { get; set; }
 
        [Column("trainer_class")] 
                public byte TrainerClass { get; set; }
 
        [Column("trainer_race")] 
                public byte TrainerRace { get; set; }
 
        [Column("minrangedmg")] 
                public float Minrangedmg { get; set; }
 
        [Column("maxrangedmg")] 
                public float Maxrangedmg { get; set; }
 
        [Column("rangedattackpower")] 
                public int Rangedattackpower { get; set; }
 
        [Column("type")] 
                public byte Type { get; set; }
 
        [Column("type_flags")] 
                public long TypeFlags { get; set; }
 
        [Column("lootid")] 
                public int Lootid { get; set; }
 
        [Column("pickpocketloot")] 
                public int Pickpocketloot { get; set; }
 
        [Column("skinloot")] 
                public int Skinloot { get; set; }
 
        [Column("resistance1")] 
                public short Resistance1 { get; set; }
 
        [Column("resistance2")] 
                public short Resistance2 { get; set; }
 
        [Column("resistance3")] 
                public short Resistance3 { get; set; }
 
        [Column("resistance4")] 
                public short Resistance4 { get; set; }
 
        [Column("resistance5")] 
                public short Resistance5 { get; set; }
 
        [Column("resistance6")] 
                public short Resistance6 { get; set; }
 
        [Column("PetSpellDataId")] 
                public int PetSpellDataId { get; set; }
 
        [Column("mingold")] 
                public int Mingold { get; set; }
 
        [Column("maxgold")] 
                public int Maxgold { get; set; }
 
        [Column("AIName")] 
                public string AIName { get; set; }
 
        [Column("MovementType")] 
                public byte? MovementType { get; set; }
 
        [Column("InhabitType")] 
                public byte InhabitType { get; set; }
 
        [Column("Civilian")] 
                public byte Civilian { get; set; }
 
        [Column("RacialLeader")] 
                public byte RacialLeader { get; set; }
 
        [Column("RegenHealth")] 
                public byte RegenHealth { get; set; }
 
        [Column("equipment_id")] 
                public int EquipmentID { get; set; }
 
        [Column("trainer_id")] 
                public int TrainerID { get; set; }
 
        [Column("vendor_id")] 
                public int VendorID { get; set; }
 
        [Column("mechanic_immune_mask")] 
                public long MechanicImmuneMask { get; set; }
 
        [Column("flags_extra")] 
                public long FlagsExtra { get; set; }
 
        [Column("ScriptName")] 
                public string ScriptName { get; set; }
    }
}
