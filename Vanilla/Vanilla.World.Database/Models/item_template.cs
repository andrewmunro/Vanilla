using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace Vanilla.Database.World.Models
{

	    [Table("item_template", Schema="mangos")]

    public partial class item_template
    {
 
        [Column("entry")] 
		        public int entry { get; set; }
 
        [Column("class")] 
		        public byte @class { get; set; }
 
        [Column("subclass")] 
		        public byte subclass { get; set; }
 
        [Column("name")] 
		        public string name { get; set; }
 
        [Column("displayid")] 
		        public int displayid { get; set; }
 
        [Column("Quality")] 
		        public byte Quality { get; set; }
 
        [Column("Flags")] 
		        public long Flags { get; set; }
 
        [Column("BuyCount")] 
		        public byte BuyCount { get; set; }
 
        [Column("BuyPrice")] 
		        public long BuyPrice { get; set; }
 
        [Column("SellPrice")] 
		        public long SellPrice { get; set; }
 
        [Column("InventoryType")] 
		        public byte InventoryType { get; set; }
 
        [Column("AllowableClass")] 
		        public int AllowableClass { get; set; }
 
        [Column("AllowableRace")] 
		        public int AllowableRace { get; set; }
 
        [Column("ItemLevel")] 
		        public byte ItemLevel { get; set; }
 
        [Column("RequiredLevel")] 
		        public byte RequiredLevel { get; set; }
 
        [Column("RequiredSkill")] 
		        public int RequiredSkill { get; set; }
 
        [Column("RequiredSkillRank")] 
		        public int RequiredSkillRank { get; set; }
 
        [Column("requiredspell")] 
		        public int requiredspell { get; set; }
 
        [Column("requiredhonorrank")] 
		        public int requiredhonorrank { get; set; }
 
        [Column("RequiredCityRank")] 
		        public int RequiredCityRank { get; set; }
 
        [Column("RequiredReputationFaction")] 
		        public int RequiredReputationFaction { get; set; }
 
        [Column("RequiredReputationRank")] 
		        public int RequiredReputationRank { get; set; }
 
        [Column("maxcount")] 
		        public int maxcount { get; set; }
 
        [Column("stackable")] 
		        public int stackable { get; set; }
 
        [Column("ContainerSlots")] 
		        public byte ContainerSlots { get; set; }
 
        [Column("stat_type1")] 
		        public byte stat_type1 { get; set; }
 
        [Column("stat_value1")] 
		        public short stat_value1 { get; set; }
 
        [Column("stat_type2")] 
		        public byte stat_type2 { get; set; }
 
        [Column("stat_value2")] 
		        public short stat_value2 { get; set; }
 
        [Column("stat_type3")] 
		        public byte stat_type3 { get; set; }
 
        [Column("stat_value3")] 
		        public short stat_value3 { get; set; }
 
        [Column("stat_type4")] 
		        public byte stat_type4 { get; set; }
 
        [Column("stat_value4")] 
		        public short stat_value4 { get; set; }
 
        [Column("stat_type5")] 
		        public byte stat_type5 { get; set; }
 
        [Column("stat_value5")] 
		        public short stat_value5 { get; set; }
 
        [Column("stat_type6")] 
		        public byte stat_type6 { get; set; }
 
        [Column("stat_value6")] 
		        public short stat_value6 { get; set; }
 
        [Column("stat_type7")] 
		        public byte stat_type7 { get; set; }
 
        [Column("stat_value7")] 
		        public short stat_value7 { get; set; }
 
        [Column("stat_type8")] 
		        public byte stat_type8 { get; set; }
 
        [Column("stat_value8")] 
		        public short stat_value8 { get; set; }
 
        [Column("stat_type9")] 
		        public byte stat_type9 { get; set; }
 
        [Column("stat_value9")] 
		        public short stat_value9 { get; set; }
 
        [Column("stat_type10")] 
		        public byte stat_type10 { get; set; }
 
        [Column("stat_value10")] 
		        public short stat_value10 { get; set; }
 
        [Column("dmg_min1")] 
		        public float dmg_min1 { get; set; }
 
        [Column("dmg_max1")] 
		        public float dmg_max1 { get; set; }
 
        [Column("dmg_type1")] 
		        public byte dmg_type1 { get; set; }
 
        [Column("dmg_min2")] 
		        public float dmg_min2 { get; set; }
 
        [Column("dmg_max2")] 
		        public float dmg_max2 { get; set; }
 
        [Column("dmg_type2")] 
		        public byte dmg_type2 { get; set; }
 
        [Column("dmg_min3")] 
		        public float dmg_min3 { get; set; }
 
        [Column("dmg_max3")] 
		        public float dmg_max3 { get; set; }
 
        [Column("dmg_type3")] 
		        public byte dmg_type3 { get; set; }
 
        [Column("dmg_min4")] 
		        public float dmg_min4 { get; set; }
 
        [Column("dmg_max4")] 
		        public float dmg_max4 { get; set; }
 
        [Column("dmg_type4")] 
		        public byte dmg_type4 { get; set; }
 
        [Column("dmg_min5")] 
		        public float dmg_min5 { get; set; }
 
        [Column("dmg_max5")] 
		        public float dmg_max5 { get; set; }
 
        [Column("dmg_type5")] 
		        public byte dmg_type5 { get; set; }
 
        [Column("armor")] 
		        public int armor { get; set; }
 
        [Column("holy_res")] 
		        public byte holy_res { get; set; }
 
        [Column("fire_res")] 
		        public byte fire_res { get; set; }
 
        [Column("nature_res")] 
		        public byte nature_res { get; set; }
 
        [Column("frost_res")] 
		        public byte frost_res { get; set; }
 
        [Column("shadow_res")] 
		        public byte shadow_res { get; set; }
 
        [Column("arcane_res")] 
		        public byte arcane_res { get; set; }
 
        [Column("delay")] 
		        public int delay { get; set; }
 
        [Column("ammo_type")] 
		        public byte ammo_type { get; set; }
 
        [Column("RangedModRange")] 
		        public float RangedModRange { get; set; }
 
        [Column("spellid_1")] 
		        public int spellid_1 { get; set; }
 
        [Column("spelltrigger_1")] 
		        public byte spelltrigger_1 { get; set; }
 
        [Column("spellcharges_1")] 
		        public sbyte spellcharges_1 { get; set; }
 
        [Column("spellppmRate_1")] 
		        public float spellppmRate_1 { get; set; }
 
        [Column("spellcooldown_1")] 
		        public int spellcooldown_1 { get; set; }
 
        [Column("spellcategory_1")] 
		        public int spellcategory_1 { get; set; }
 
        [Column("spellcategorycooldown_1")] 
		        public int spellcategorycooldown_1 { get; set; }
 
        [Column("spellid_2")] 
		        public int spellid_2 { get; set; }
 
        [Column("spelltrigger_2")] 
		        public byte spelltrigger_2 { get; set; }
 
        [Column("spellcharges_2")] 
		        public sbyte spellcharges_2 { get; set; }
 
        [Column("spellppmRate_2")] 
		        public float spellppmRate_2 { get; set; }
 
        [Column("spellcooldown_2")] 
		        public int spellcooldown_2 { get; set; }
 
        [Column("spellcategory_2")] 
		        public int spellcategory_2 { get; set; }
 
        [Column("spellcategorycooldown_2")] 
		        public int spellcategorycooldown_2 { get; set; }
 
        [Column("spellid_3")] 
		        public int spellid_3 { get; set; }
 
        [Column("spelltrigger_3")] 
		        public byte spelltrigger_3 { get; set; }
 
        [Column("spellcharges_3")] 
		        public sbyte spellcharges_3 { get; set; }
 
        [Column("spellppmRate_3")] 
		        public float spellppmRate_3 { get; set; }
 
        [Column("spellcooldown_3")] 
		        public int spellcooldown_3 { get; set; }
 
        [Column("spellcategory_3")] 
		        public int spellcategory_3 { get; set; }
 
        [Column("spellcategorycooldown_3")] 
		        public int spellcategorycooldown_3 { get; set; }
 
        [Column("spellid_4")] 
		        public int spellid_4 { get; set; }
 
        [Column("spelltrigger_4")] 
		        public byte spelltrigger_4 { get; set; }
 
        [Column("spellcharges_4")] 
		        public sbyte spellcharges_4 { get; set; }
 
        [Column("spellppmRate_4")] 
		        public float spellppmRate_4 { get; set; }
 
        [Column("spellcooldown_4")] 
		        public int spellcooldown_4 { get; set; }
 
        [Column("spellcategory_4")] 
		        public int spellcategory_4 { get; set; }
 
        [Column("spellcategorycooldown_4")] 
		        public int spellcategorycooldown_4 { get; set; }
 
        [Column("spellid_5")] 
		        public int spellid_5 { get; set; }
 
        [Column("spelltrigger_5")] 
		        public byte spelltrigger_5 { get; set; }
 
        [Column("spellcharges_5")] 
		        public sbyte spellcharges_5 { get; set; }
 
        [Column("spellppmRate_5")] 
		        public float spellppmRate_5 { get; set; }
 
        [Column("spellcooldown_5")] 
		        public int spellcooldown_5 { get; set; }
 
        [Column("spellcategory_5")] 
		        public int spellcategory_5 { get; set; }
 
        [Column("spellcategorycooldown_5")] 
		        public int spellcategorycooldown_5 { get; set; }
 
        [Column("bonding")] 
		        public byte bonding { get; set; }
 
        [Column("description")] 
		        public string description { get; set; }
 
        [Column("PageText")] 
		        public int PageText { get; set; }
 
        [Column("LanguageID")] 
		        public byte LanguageID { get; set; }
 
        [Column("PageMaterial")] 
		        public byte PageMaterial { get; set; }
 
        [Column("startquest")] 
		        public int startquest { get; set; }
 
        [Column("lockid")] 
		        public int lockid { get; set; }
 
        [Column("Material")] 
		        public sbyte Material { get; set; }
 
        [Column("sheath")] 
		        public byte sheath { get; set; }
 
        [Column("RandomProperty")] 
		        public int RandomProperty { get; set; }
 
        [Column("block")] 
		        public int block { get; set; }
 
        [Column("itemset")] 
		        public int itemset { get; set; }
 
        [Column("MaxDurability")] 
		        public int MaxDurability { get; set; }
 
        [Column("area")] 
		        public int area { get; set; }
 
        [Column("Map")] 
		        public short Map { get; set; }
 
        [Column("BagFamily")] 
		        public int BagFamily { get; set; }
 
        [Column("ScriptName")] 
		        public string ScriptName { get; set; }
 
        [Column("DisenchantID")] 
		        public int DisenchantID { get; set; }
 
        [Column("FoodType")] 
		        public byte FoodType { get; set; }
 
        [Column("minMoneyLoot")] 
		        public long minMoneyLoot { get; set; }
 
        [Column("maxMoneyLoot")] 
		        public long maxMoneyLoot { get; set; }
 
        [Column("Duration")] 
		        public long Duration { get; set; }
 
        [Column("ExtraFlags")] 
		        public bool ExtraFlags { get; set; }
    }
}
