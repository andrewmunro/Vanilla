using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite;
using Vanilla.World.Tools.DBC.Tables;

namespace Vanilla.World.Tools
{
    public class DBConverter
    {
        public static string DBC_LOCATION = INI.GetValue(ConfigSections.DEV, ConfigValues.DBC_LOCATION);

        public static SQLiteConnection SQLite;

        public static void Convert()
        {
            //GenerateTable<ChrRacesEntry>(CSVToChrRacesEntry, DBC_LOCATION + "ChrRaces.csv", ConfigValues.DBC);
            //GenerateTable<EmotesTextEntry>(CSVToEmotesTextEntry, DBC_LOCATION + "EmotesText.csv", ConfigValues.DBC);
            //GenerateTable<AreaTableEntry>(CSVToAreaTableEntry, DBC_LOCATION + "AreaTable.csv", ConfigValues.DBC);
            //GenerateTable<AreaTriggerEntry>(CSVToAreaTriggerEntry, DBC_LOCATION + "AreaTrigger.csv", ConfigValues.DBC);
            //GenerateTable<ChrStartingOutfitEntry>(CSVToChrStartingEntry, DBC_LOCATION + "CharStartOutfit.csv", ConfigValues.DBC);
            //GenerateTable<ItemTemplateEntry>(CSVToChrItemTemplateEntry, DBC_LOCATION + "item_template.csv", ConfigValues.DBC);
            //GenerateTable<CreatureTemplateEntry>(CSVToCreatureTemplateEntry, DBC_LOCATION + "creature_template.csv", ConfigValues.DBC);
            //GenerateTable<CreatureEntry>(CSVToCreatureEntry, DBC_LOCATION + "creature.csv", ConfigValues.WORLD);
            //GenerateTable<EmotesEntry>(CSVToEmotesEntry, DBC_LOCATION + "Emotes.csv", ConfigValues.DBC);
            GenerateTable<SpellEntry>(CSVToSpellEntry, DBC_LOCATION + "Spell.csv", ConfigValues.DBC);
            //GenerateTable<SpellAuraNamesEntry>(CSVToSpellAuraNamesEntry, DBC_LOCATION + "SpellAuraNames.csv", ConfigValues.DBC);

            Console.Write(true);
            Console.Read();
        }

        public static void GenerateTable<T>(Func<string[], T> Converter, string url, string database)
        {
            SQLite = new SQLiteConnection(INI.GetValue(ConfigSections.DB, database));
            Log.Print(LogType.Debug, "Dropping table " + typeof(T).Name);
            SQLite.DropTable<T>();

            List<T> ConvertedEntries = Convert<T>(Converter, url);

            Log.Print(LogType.Debug, "Creating table " + typeof(T).Name);
            SQLite.CreateTable<T>();

            float index = 0;
            ConvertedEntries.ForEach(e => 
                {
                    Console.Clear();
                    float percent = (index / ConvertedEntries.Count) * 100;
                    Console.WriteLine(percent + "% - [" + index + "/" + ConvertedEntries.Count + "]");


                    SQLite.Insert(e);
                    index++;
                });
            Log.Print(LogType.Debug, "Added " + ConvertedEntries.Count + " entries");
            SQLite.Close();
        }

        public static List<T> Convert<T>(Func<string[], T> converter, string url)
        {
            List<string> csvEntrys = File.ReadAllLines(url).ToList<string>();

            List<T> convertedEntrys = new List<T>();

            csvEntrys.ForEach(e => convertedEntrys.Add(converter(e.Split(','))));
            return convertedEntrys;
        }

        private static ChrRacesEntry CSVToChrRacesEntry(string[] data)
        {
            return new ChrRacesEntry()
            {
                RaceID = int.Parse(data[0]),
                DisplayName = data[17].Replace("\"", ""),
                FactionID = int.Parse(data[2]),
                ModelM = int.Parse(data[4]),
                ModelF = int.Parse(data[5]),
                TeamID = int.Parse(data[8]),
                StartingTaxiMask = int.Parse(data[14]),
                CinematicSequence = int.Parse(data[16])
            };
        }

        private static CreatureEntry CSVToCreatureEntry(string[] data)
        {
            return new CreatureEntry()
                {
                    guid = int.Parse(data[0]),
                    id = int.Parse(data[1]),
                    map = int.Parse(data[2]),
                    modelid = int.Parse(data[3]),
                    equipment_id = int.Parse(data[4]),
                    position_x = float.Parse(data[5]),
                    position_y = float.Parse(data[6]),
                    position_z = float.Parse(data[7]),
                    orientation = float.Parse(data[8]),
                    spawntimesecs = int.Parse(data[9]),
                    spawndist = int.Parse(data[10]),
                    currentwaypoint = int.Parse(data[11]),
                    curhealth = int.Parse(data[12]),
                    curmana = int.Parse(data[13]),
                    DeathState = int.Parse(data[14]),
                    MovementType = int.Parse(data[15])
                };
        }

        private static EmotesEntry CSVToEmotesEntry(string[] data)
        {
            return new EmotesEntry()
                {
                    ID = uint.Parse(data[0]),
                    Name = data[1],
                    Flags = int.Parse(data[2]),
                    AnimationID = int.Parse(data[3]),
                    EmoteType = int.Parse(data[4]),
                    UnitStandState = int.Parse(data[5]),
                    SoundID = int.Parse(data[6])
                };
        }

        private static CreatureTemplateEntry CSVToCreatureTemplateEntry(string[] data)
        {
            return new CreatureTemplateEntry()
                {
                    entry = int.Parse(data[(int) CreatureTemplateColumn.entry]),
                    KillCredit1 = int.Parse(data[(int) CreatureTemplateColumn.KillCredit1]),
                    KillCredit2 = int.Parse(data[(int) CreatureTemplateColumn.KillCredit2]),
                    modelid_1 = int.Parse(data[(int) CreatureTemplateColumn.modelid_1]),
                    modelid_2 = int.Parse(data[(int) CreatureTemplateColumn.modelid_2]),
                    name = data[(int) CreatureTemplateColumn.name],
                    subname = data[(int) CreatureTemplateColumn.subname],
                    gossip_menu_id = int.Parse(data[(int) CreatureTemplateColumn.gossip_menu_id]),
                    minlevel = int.Parse(data[(int) CreatureTemplateColumn.minlevel]),
                    maxlevel = int.Parse(data[(int) CreatureTemplateColumn.maxlevel]),
                    minhealth = int.Parse(data[(int) CreatureTemplateColumn.minhealth]),
                    maxhealth = int.Parse(data[(int) CreatureTemplateColumn.maxhealth]),
                    minmana = int.Parse(data[(int) CreatureTemplateColumn.minmana]),
                    maxmana = int.Parse(data[(int) CreatureTemplateColumn.maxmana]),
                    armor = int.Parse(data[(int) CreatureTemplateColumn.armor]),
                    faction_A = int.Parse(data[(int) CreatureTemplateColumn.faction_A]),
                    faction_H = int.Parse(data[(int) CreatureTemplateColumn.faction_H]),
                    npcflag = int.Parse(data[(int) CreatureTemplateColumn.npcflag]),
                    speed_walk = float.Parse(data[(int) CreatureTemplateColumn.speed_walk]),
                    speed_run = float.Parse(data[(int) CreatureTemplateColumn.speed_run]),
                    scale = float.Parse(data[(int) CreatureTemplateColumn.scale]),
                    rank = int.Parse(data[(int) CreatureTemplateColumn.rank]),
                    mindmg = int.Parse(data[(int) CreatureTemplateColumn.mindmg]),
                    maxdmg = int.Parse(data[(int) CreatureTemplateColumn.maxdmg]),
                    dmgschool = int.Parse(data[(int) CreatureTemplateColumn.dmgschool]),
                    attackpower = int.Parse(data[(int) CreatureTemplateColumn.attackpower]),
                    dmg_multiplier = int.Parse(data[(int) CreatureTemplateColumn.dmg_multiplier]),
                    baseattacktime = int.Parse(data[(int) CreatureTemplateColumn.baseattacktime]),
                    rangeattacktime = int.Parse(data[(int) CreatureTemplateColumn.rangeattacktime]),
                    unit_class = int.Parse(data[(int) CreatureTemplateColumn.unit_class]),
                    unit_flags = int.Parse(data[(int) CreatureTemplateColumn.unit_flags]),
                    dynamicflags = int.Parse(data[(int) CreatureTemplateColumn.dynamicflags]),
                    family = int.Parse(data[(int) CreatureTemplateColumn.family]),
                    trainer_type = int.Parse(data[(int) CreatureTemplateColumn.trainer_type]),
                    trainer_spell = int.Parse(data[(int) CreatureTemplateColumn.trainer_spell]),
                    trainer_class = int.Parse(data[(int) CreatureTemplateColumn.trainer_class]),
                    trainer_race = int.Parse(data[(int) CreatureTemplateColumn.trainer_race]),
                    minrangedmg = float.Parse(data[(int) CreatureTemplateColumn.minrangedmg]),
                    maxrangedmg = float.Parse(data[(int) CreatureTemplateColumn.maxrangedmg]),
                    rangedattackpower = int.Parse(data[(int) CreatureTemplateColumn.rangedattackpower]),
                    type = int.Parse(data[(int) CreatureTemplateColumn.type]),
                    type_flags = int.Parse(data[(int) CreatureTemplateColumn.type_flags]),
                    lootid = int.Parse(data[(int) CreatureTemplateColumn.lootid]),
                    pickpocketloot = int.Parse(data[(int) CreatureTemplateColumn.pickpocketloot]),
                    skinloot = int.Parse(data[(int) CreatureTemplateColumn.skinloot]),
                    resistance1 = int.Parse(data[(int) CreatureTemplateColumn.resistance1]),
                    resistance2 = int.Parse(data[(int) CreatureTemplateColumn.resistance2]),
                    resistance3 = int.Parse(data[(int) CreatureTemplateColumn.resistance3]),
                    resistance4 = int.Parse(data[(int) CreatureTemplateColumn.resistance4]),
                    resistance5 = int.Parse(data[(int) CreatureTemplateColumn.resistance5]),
                    resistance6 = int.Parse(data[(int) CreatureTemplateColumn.resistance6]),
                    spell1 = int.Parse(data[(int) CreatureTemplateColumn.spell1]),
                    spell2 = int.Parse(data[(int) CreatureTemplateColumn.spell2]),
                    spell3 = int.Parse(data[(int) CreatureTemplateColumn.spell3]),
                    spell4 = int.Parse(data[(int) CreatureTemplateColumn.spell4]),
                    PetSpellDataId = int.Parse(data[(int) CreatureTemplateColumn.PetSpellDataId]),
                    mingold = int.Parse(data[(int) CreatureTemplateColumn.mingold]),
                    maxgold = int.Parse(data[(int) CreatureTemplateColumn.maxgold]),
                    AIName = data[(int) CreatureTemplateColumn.AIName],
                    MovementType = int.Parse(data[(int) CreatureTemplateColumn.MovementType]),
                    InhabitType = int.Parse(data[(int) CreatureTemplateColumn.InhabitType]),
                    Civilian = int.Parse(data[(int) CreatureTemplateColumn.Civilian]),
                    RacialLeader = int.Parse(data[(int) CreatureTemplateColumn.RacialLeader]),
                    RegenHealth = int.Parse(data[(int) CreatureTemplateColumn.RegenHealth]),
                    equipment_id = int.Parse(data[(int) CreatureTemplateColumn.equipment_id]),
                    trainer_id = int.Parse(data[(int) CreatureTemplateColumn.trainer_id]),
                    vendor_id = int.Parse(data[(int) CreatureTemplateColumn.vendor_id]),
                    mechanic_immune_mask = int.Parse(data[(int) CreatureTemplateColumn.mechanic_immune_mask]),
                    flags_extra = int.Parse(data[(int) CreatureTemplateColumn.flags_extra]),
                    ScriptName = data[(int) CreatureTemplateColumn.ScriptName]
                };
        }

        private static ItemTemplateEntry CSVToChrItemTemplateEntry(string[] data)
        {
            return new ItemTemplateEntry()
            {
                entry = int.Parse(data[(int)ItemTemplateColumn.entry]),
                classID = int.Parse(data[(int)ItemTemplateColumn.classID]),
                subclass = int.Parse(data[(int)ItemTemplateColumn.subclass]),
                name = data[(int)ItemTemplateColumn.name],
                displayid = int.Parse(data[(int)ItemTemplateColumn.displayid]),
                Quality = int.Parse(data[(int)ItemTemplateColumn.Quality]),
                Flags = int.Parse(data[(int)ItemTemplateColumn.Flags]),
                BuyCount = int.Parse(data[(int)ItemTemplateColumn.BuyCount]),
                BuyPrice = int.Parse(data[(int)ItemTemplateColumn.BuyPrice]),
                SellPrice = int.Parse(data[(int)ItemTemplateColumn.SellPrice]),
                InventoryType = int.Parse(data[(int)ItemTemplateColumn.InventoryType]),
                AllowableClass = int.Parse(data[(int)ItemTemplateColumn.AllowableClass]),
                AllowableRace = int.Parse(data[(int)ItemTemplateColumn.AllowableRace]),
                ItemLevel = int.Parse(data[(int)ItemTemplateColumn.ItemLevel]),
                RequiredLevel = int.Parse(data[(int)ItemTemplateColumn.RequiredLevel]),
                RequiredSkill = int.Parse(data[(int)ItemTemplateColumn.RequiredSkill]),
                RequiredSkillRank = int.Parse(data[(int)ItemTemplateColumn.RequiredSkillRank]),
                requiredspell = int.Parse(data[(int)ItemTemplateColumn.requiredspell]),
                requiredhonorrank = int.Parse(data[(int)ItemTemplateColumn.requiredhonorrank]),
                RequiredCityRank = int.Parse(data[(int)ItemTemplateColumn.RequiredCityRank]),
                RequiredReputationFaction = int.Parse(data[(int)ItemTemplateColumn.RequiredReputationFaction]),
                RequiredReputationRank = int.Parse(data[(int)ItemTemplateColumn.RequiredReputationRank]),
                maxcount = int.Parse(data[(int)ItemTemplateColumn.maxcount]),
                stackable = int.Parse(data[(int)ItemTemplateColumn.stackable]),
                ContainerSlots = int.Parse(data[(int)ItemTemplateColumn.ContainerSlots]),
                stat_type1 = int.Parse(data[(int)ItemTemplateColumn.stat_type1]),
                stat_value1 = int.Parse(data[(int)ItemTemplateColumn.stat_value1]),
                stat_type2 = int.Parse(data[(int)ItemTemplateColumn.stat_type2]),
                stat_value2 = int.Parse(data[(int)ItemTemplateColumn.stat_value2]),
                stat_type3 = int.Parse(data[(int)ItemTemplateColumn.stat_type3]),
                stat_value3 = int.Parse(data[(int)ItemTemplateColumn.stat_value3]),
                stat_type4 = int.Parse(data[(int)ItemTemplateColumn.stat_type4]),
                stat_value4 = int.Parse(data[(int)ItemTemplateColumn.stat_value4]),
                stat_type5 = int.Parse(data[(int)ItemTemplateColumn.stat_type5]),
                stat_value5 = int.Parse(data[(int)ItemTemplateColumn.stat_value5]),
                stat_type6 = int.Parse(data[(int)ItemTemplateColumn.stat_type6]),
                stat_value6 = int.Parse(data[(int)ItemTemplateColumn.stat_value6]),
                stat_type7 = int.Parse(data[(int)ItemTemplateColumn.stat_type7]),
                stat_value7 = int.Parse(data[(int)ItemTemplateColumn.stat_value7]),
                stat_type8 = int.Parse(data[(int)ItemTemplateColumn.stat_type8]),
                stat_value8 = int.Parse(data[(int)ItemTemplateColumn.stat_value8]),
                stat_type9 = int.Parse(data[(int)ItemTemplateColumn.stat_type9]),
                stat_value9 = int.Parse(data[(int)ItemTemplateColumn.stat_value9]),
                stat_type10 = int.Parse(data[(int)ItemTemplateColumn.stat_type10]),
                stat_value10 = int.Parse(data[(int)ItemTemplateColumn.stat_value10]),
                dmg_min1 = float.Parse(data[(int)ItemTemplateColumn.dmg_min1]),
                dmg_max1 = float.Parse(data[(int)ItemTemplateColumn.dmg_max1]),
                dmg_type1 = int.Parse(data[(int)ItemTemplateColumn.dmg_type1]),
                dmg_min2 = float.Parse(data[(int)ItemTemplateColumn.dmg_min2]),
                dmg_max2 = float.Parse(data[(int)ItemTemplateColumn.dmg_max2]),
                dmg_type2 = int.Parse(data[(int)ItemTemplateColumn.dmg_type2]),
                dmg_min3 = float.Parse(data[(int)ItemTemplateColumn.dmg_min3]),
                dmg_max3 = float.Parse(data[(int)ItemTemplateColumn.dmg_max3]),
                dmg_type3 = int.Parse(data[(int)ItemTemplateColumn.dmg_type3]),
                dmg_min4 = float.Parse(data[(int)ItemTemplateColumn.dmg_min4]),
                dmg_max4 = float.Parse(data[(int)ItemTemplateColumn.dmg_max4]),
                dmg_type4 = int.Parse(data[(int)ItemTemplateColumn.dmg_type4]),
                dmg_min5 = float.Parse(data[(int)ItemTemplateColumn.dmg_min5]),
                dmg_max5 = float.Parse(data[(int)ItemTemplateColumn.dmg_max5]),
                dmg_type5 = int.Parse(data[(int)ItemTemplateColumn.dmg_type5]),
                armor = int.Parse(data[(int)ItemTemplateColumn.armor]),
                holy_res = int.Parse(data[(int)ItemTemplateColumn.holy_res]),
                fire_res = int.Parse(data[(int)ItemTemplateColumn.fire_res]),
                nature_res = int.Parse(data[(int)ItemTemplateColumn.nature_res]),
                frost_res = int.Parse(data[(int)ItemTemplateColumn.frost_res]),
                shadow_res = int.Parse(data[(int)ItemTemplateColumn.shadow_res]),
                arcane_res = int.Parse(data[(int)ItemTemplateColumn.arcane_res]),
                delay = int.Parse(data[(int)ItemTemplateColumn.delay]),
                ammo_type = int.Parse(data[(int)ItemTemplateColumn.ammo_type]),
                RangedModRange = float.Parse(data[(int)ItemTemplateColumn.RangedModRange]),
                spellid_1 = int.Parse(data[(int)ItemTemplateColumn.spellid_1]),
                spelltrigger_1 = int.Parse(data[(int)ItemTemplateColumn.spelltrigger_1]),
                spellcharges_1 = int.Parse(data[(int)ItemTemplateColumn.spellcharges_1]),
                spellppmRate_1 = float.Parse(data[(int)ItemTemplateColumn.spellppmRate_1]),
                spellcooldown_1 = int.Parse(data[(int)ItemTemplateColumn.spellcooldown_1]),
                spellcategory_1 = int.Parse(data[(int)ItemTemplateColumn.spellcategory_1]),
                spellcategorycooldown_1 = int.Parse(data[(int)ItemTemplateColumn.spellcategorycooldown_1]),
                spellid_2 = int.Parse(data[(int)ItemTemplateColumn.spellid_2]),
                spelltrigger_2 = int.Parse(data[(int)ItemTemplateColumn.spelltrigger_2]),
                spellcharges_2 = int.Parse(data[(int)ItemTemplateColumn.spellcharges_2]),
                spellppmRate_2 = float.Parse(data[(int)ItemTemplateColumn.spellppmRate_2]),
                spellcooldown_2 = int.Parse(data[(int)ItemTemplateColumn.spellcooldown_2]),
                spellcategory_2 = int.Parse(data[(int)ItemTemplateColumn.spellcategory_2]),
                spellcategorycooldown_2 = int.Parse(data[(int)ItemTemplateColumn.spellcategorycooldown_2]),
                spellid_3 = int.Parse(data[(int)ItemTemplateColumn.spellid_3]),
                spelltrigger_3 = int.Parse(data[(int)ItemTemplateColumn.spelltrigger_3]),
                spellcharges_3 = int.Parse(data[(int)ItemTemplateColumn.spellcharges_3]),
                spellppmRate_3 = float.Parse(data[(int)ItemTemplateColumn.spellppmRate_3]),
                spellcooldown_3 = int.Parse(data[(int)ItemTemplateColumn.spellcooldown_3]),
                spellcategory_3 = int.Parse(data[(int)ItemTemplateColumn.spellcategory_3]),
                spellcategorycooldown_3 = int.Parse(data[(int)ItemTemplateColumn.spellcategorycooldown_3]),
                spellid_4 = int.Parse(data[(int)ItemTemplateColumn.spellid_4]),
                spelltrigger_4 = int.Parse(data[(int)ItemTemplateColumn.spelltrigger_4]),
                spellcharges_4 = int.Parse(data[(int)ItemTemplateColumn.spellcharges_4]),
                spellppmRate_4 = float.Parse(data[(int)ItemTemplateColumn.spellppmRate_4]),
                spellcooldown_4 = int.Parse(data[(int)ItemTemplateColumn.spellcooldown_4]),
                spellcategory_4 = int.Parse(data[(int)ItemTemplateColumn.spellcategory_4]),
                spellcategorycooldown_4 = int.Parse(data[(int)ItemTemplateColumn.spellcategorycooldown_4]),
                spellid_5 = int.Parse(data[(int)ItemTemplateColumn.spellid_5]),
                spelltrigger_5 = int.Parse(data[(int)ItemTemplateColumn.spelltrigger_5]),
                spellcharges_5 = int.Parse(data[(int)ItemTemplateColumn.spellcharges_5]),
                spellppmRate_5 = float.Parse(data[(int)ItemTemplateColumn.spellppmRate_5]),
                spellcooldown_5 = int.Parse(data[(int)ItemTemplateColumn.spellcooldown_5]),
                spellcategory_5 = int.Parse(data[(int)ItemTemplateColumn.spellcategory_5]),
                spellcategorycooldown_5 = int.Parse(data[(int)ItemTemplateColumn.spellcategorycooldown_5]),
                bonding = int.Parse(data[(int)ItemTemplateColumn.bonding]),
                description = data[(int)ItemTemplateColumn.description],
                PageText = int.Parse(data[(int)ItemTemplateColumn.PageText]),
                LanguageID = int.Parse(data[(int)ItemTemplateColumn.LanguageID]),
                PageMaterial = int.Parse(data[(int)ItemTemplateColumn.PageMaterial]),
                startquest = int.Parse(data[(int)ItemTemplateColumn.startquest]),
                lockid = int.Parse(data[(int)ItemTemplateColumn.lockid]),
                Material = int.Parse(data[(int)ItemTemplateColumn.Material]),
                sheath = int.Parse(data[(int)ItemTemplateColumn.sheath]),
                RandomProperty = int.Parse(data[(int)ItemTemplateColumn.RandomProperty]),
                block = int.Parse(data[(int)ItemTemplateColumn.block]),
                itemset = int.Parse(data[(int)ItemTemplateColumn.itemset]),
                MaxDurability = int.Parse(data[(int)ItemTemplateColumn.MaxDurability]),
                area = int.Parse(data[(int)ItemTemplateColumn.area]),
                Map = int.Parse(data[(int)ItemTemplateColumn.Map]),
                BagFamily = int.Parse(data[(int)ItemTemplateColumn.BagFamily]),
                ScriptName = data[(int)ItemTemplateColumn.ScriptName],
                DisenchantID = int.Parse(data[(int)ItemTemplateColumn.DisenchantID]),
                FoodType = int.Parse(data[(int)ItemTemplateColumn.FoodType]),
                minMoneyLoot = int.Parse(data[(int)ItemTemplateColumn.minMoneyLoot]),
                maxMoneyLoot = int.Parse(data[(int)ItemTemplateColumn.maxMoneyLoot]),
                Duration = int.Parse(data[(int)ItemTemplateColumn.Duration]),
                ExtraFlags = int.Parse(data[(int)ItemTemplateColumn.ExtraFlags])
            };
        }

        private static ChrStartingOutfitEntry CSVToChrStartingEntry(string[] data)
        {
            return new ChrStartingOutfitEntry()
                {
                    Race = int.Parse(data[1]),
                    Class = int.Parse(data[2]),
                    Gender = int.Parse(data[3]),
                    ItemID = GetCSVStringFromIndex(data, 2 + 3, 12),
                    ItemDisplayID = GetCSVStringFromIndex(data, 14 + 3, 12),
                    ItemInventoryType = GetCSVStringFromIndex(data, 26 + 3, 12)
                };
        }

        private static string GetCSVStringFromIndex(string[] data, int startIndex, int length)
        {
            String result = "";
            for (int i = 0; i < length; i++)
            {
                result += data[startIndex + i] + ",";
            }

            string[] output = new string[length];
            Array.Copy(data, startIndex, output, 0, length);
            return String.Join(",", output);
        }

        private static EmotesTextEntry CSVToEmotesTextEntry(string[] data)
        {
            return new EmotesTextEntry()
            {
                ID = int.Parse(data[0]),
                Name = data[1].Replace("\"", ""),
                TextID = uint.Parse(data[2]),
                EmoteText = int.Parse(data[3])
            };
        }

        private static AreaTableEntry CSVToAreaTableEntry(string[] data)
        {
            return new AreaTableEntry()
            {
                Name = data[11].Replace("\"", ""),
                ID = int.Parse(data[0]),
                MapID = int.Parse(data[1]),
                Zone = int.Parse(data[2]),
                ExploreFlag = int.Parse(data[3]),
                Flag = int.Parse(data[4]),
                Team = int.Parse(data[20])
            };
        }

        private static AreaTriggerEntry CSVToAreaTriggerEntry(string[] data)
        {
            return new AreaTriggerEntry()
            {
                ID = int.Parse(data[0]),
                MapID = int.Parse(data[1]),
                X = float.Parse(data[2]),
                Y = float.Parse(data[3]),
                Z = float.Parse(data[4]),
                Radius = float.Parse(data[5]),
                BoxX = float.Parse(data[6]),
                BoxY = float.Parse(data[7]),
                BoxZ = float.Parse(data[8]),
                BoxOrientation = float.Parse(data[9]),
            };
        }

        static float ParseOrDefault(string text)
        {
            float tmp;
            float.TryParse(text, out tmp);
            return tmp;
        }

        private static SpellEntry CSVToSpellEntry(string[] data)
        {
            SpellEntry se = new SpellEntry();
            se.ID = (int)ParseOrDefault(data[(int)SpellEntryColumn.Id]);
            se.School = (int)ParseOrDefault(data[(int)SpellEntryColumn.School]);
            se.Category = (int)ParseOrDefault(data[(int)SpellEntryColumn.Category]);
            se.castUI = (int)ParseOrDefault(data[(int)SpellEntryColumn.castUI]);
            se.Dispel = (int)ParseOrDefault(data[(int)SpellEntryColumn.Dispel]);
            se.Mechanic = (int)ParseOrDefault(data[(int)SpellEntryColumn.Mechanic]);
/*            se.Attributes = (int)ParseOrDefault(data[(int)SpellEntryColumn.Attributes]);
            se.AttributesEx = (int)ParseOrDefault(data[(int)SpellEntryColumn.AttributesEx]);
            se.AttributesEx2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.AttributesEx2]);
            se.AttributesEx3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.AttributesEx3]);
            se.AttributesEx4 = (int)ParseOrDefault(data[(int)SpellEntryColumn.AttributesEx4]);*/
            se.Stances = (int)ParseOrDefault(data[(int)SpellEntryColumn.Stances]);
            se.StancesNot = (int)ParseOrDefault(data[(int)SpellEntryColumn.StancesNot]);
            se.Targets = (int)ParseOrDefault(data[(int)SpellEntryColumn.Targets]);
            se.TargetCreatureType = (int)ParseOrDefault(data[(int)SpellEntryColumn.TargetCreatureType]);
            se.RequiresSpellFocus = (int)ParseOrDefault(data[(int)SpellEntryColumn.RequiresSpellFocus]);
            se.CasterAuraState = (int)ParseOrDefault(data[(int)SpellEntryColumn.CasterAuraState]);
            se.TargetAuraState = (int)ParseOrDefault(data[(int)SpellEntryColumn.TargetAuraState]);
            se.CastingTimeIndex = (int)ParseOrDefault(data[(int)SpellEntryColumn.CastingTimeIndex]);
            se.RecoveryTime = (int)ParseOrDefault(data[(int)SpellEntryColumn.RecoveryTime]);
            se.CategoryRecoveryTime = (int)ParseOrDefault(data[(int)SpellEntryColumn.CategoryRecoveryTime]);
            se.InterruptFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.InterruptFlags]);
            se.AuraInterruptFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.AuraInterruptFlags]);
            se.ChannelInterruptFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.ChannelInterruptFlags]);
            se.procFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.procFlags]);
            se.procChance = (int)ParseOrDefault(data[(int)SpellEntryColumn.procChance]);
            se.procCharges = (int)ParseOrDefault(data[(int)SpellEntryColumn.procCharges]);
            se.maxLevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.maxLevel]);
            se.baseLevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.baseLevel]);
            se.spellLevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.spellLevel]);
            se.DurationIndex = (int)ParseOrDefault(data[(int)SpellEntryColumn.DurationIndex]);
            se.powerType = (int)ParseOrDefault(data[(int)SpellEntryColumn.powerType]);
            se.manaCost = (int)ParseOrDefault(data[(int)SpellEntryColumn.manaCost]);
            se.manaCostPerlevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.manaCostPerlevel]);
            se.manaPerSecond = (int)ParseOrDefault(data[(int)SpellEntryColumn.manaPerSecond]);
            se.manaPerSecondPerLevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.manaPerSecondPerLevel]);
            se.rangeIndex = (int)ParseOrDefault(data[(int)SpellEntryColumn.rangeIndex]);
            se.speed = ParseOrDefault(data[(int)SpellEntryColumn.speed]);
            se.modalNextSpell = (int)ParseOrDefault(data[(int)SpellEntryColumn.modalNextSpell]);
            se.StackAmount = (int)ParseOrDefault(data[(int)SpellEntryColumn.StackAmount]);
            se.Totem1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Totem1]);
            se.Totem2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Totem2]);
            se.Reagent1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent1]);
            se.Reagent2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent2]);
            se.Reagent3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent3]);
            se.Reagent4 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent4]);
            se.Reagent5 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent5]);
            se.Reagent6 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent6]);
            se.Reagent7 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent7]);
            se.Reagent8 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Reagent8]);
            se.ReagentCount1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount1]);
            se.ReagentCount2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount2]);
            se.ReagentCount3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount3]);
            se.ReagentCount4 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount4]);
            se.ReagentCount5 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount5]);
            se.ReagentCount6 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount6]);
            se.ReagentCount7 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount7]);
            se.ReagentCount8 = (int)ParseOrDefault(data[(int)SpellEntryColumn.ReagentCount8]);
            se.EquippedItemClass = 0;
            se.EquippedItemSubClassMask = (int)ParseOrDefault(data[(int)SpellEntryColumn.EquippedItemSubClassMask]);
            se.EquippedItemInventoryTypeMask = (int)ParseOrDefault(data[(int)SpellEntryColumn.EquippedItemInventoryTypeMask]);
            se.Effect1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Effect1]);
            se.Effect2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Effect2]);
            se.Effect3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.Effect3]);
            se.EffectDieSides1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectDieSides1]);
            se.EffectDieSides2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectDieSides2]);
            se.EffectDieSides3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectDieSides3]);
            se.EffectBaseDice1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBaseDice1]);
            se.EffectBaseDice2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBaseDice2]);
            se.EffectBaseDice3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBaseDice3]);
            se.EffectDicePerLevel1 = ParseOrDefault(data[(int)SpellEntryColumn.EffectDicePerLevel1]);
            se.EffectDicePerLevel2 = ParseOrDefault(data[(int)SpellEntryColumn.EffectDicePerLevel2]);
            se.EffectDicePerLevel3 = ParseOrDefault(data[(int)SpellEntryColumn.EffectDicePerLevel3]);
            se.EffectRealPointsPerLevel1 = ParseOrDefault(data[(int)SpellEntryColumn.EffectRealPointsPerLevel1]);
            se.EffectRealPointsPerLevel2 = ParseOrDefault(data[(int)SpellEntryColumn.EffectRealPointsPerLevel2]);
            se.EffectRealPointsPerLevel3 = ParseOrDefault(data[(int)SpellEntryColumn.EffectRealPointsPerLevel3]);
            se.EffectBasePoints1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBasePoints1]);
            se.EffectBasePoints2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBasePoints2]);
            se.EffectBasePoints3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectBasePoints3]);
            se.EffectMechanic1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMechanic1]);
            se.EffectMechanic2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMechanic2]);
            se.EffectMechanic3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMechanic3]);
            se.EffectImplicitTargetA1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetA1]);
            se.EffectImplicitTargetA2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetA2]);
            se.EffectImplicitTargetA3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetA3]);
            se.EffectImplicitTargetB1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetB1]);
            se.EffectImplicitTargetB2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetB2]);
            se.EffectImplicitTargetB3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectImplicitTargetB3]);
            se.EffectRadiusIndex1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectRadiusIndex1]);
            se.EffectRadiusIndex2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectRadiusIndex2]);
            se.EffectRadiusIndex3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectRadiusIndex3]);
            se.EffectApplyAuraName1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectApplyAuraName1]);
            se.EffectApplyAuraName2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectApplyAuraName2]);
            se.EffectApplyAuraName3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectApplyAuraName3]);
            se.EffectAmplitude1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectAmplitude1]);
            se.EffectAmplitude2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectAmplitude2]);
            se.EffectAmplitude3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectAmplitude3]);
            se.EffectMultipleValue1 = ParseOrDefault(data[(int)SpellEntryColumn.EffectMultipleValue1]);
            se.EffectMultipleValue2 = ParseOrDefault(data[(int)SpellEntryColumn.EffectMultipleValue2]);
            se.EffectMultipleValue3 = ParseOrDefault(data[(int)SpellEntryColumn.EffectMultipleValue3]);
            se.EffectChainTarget1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectChainTarget1]);
            se.EffectChainTarget2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectChainTarget2]);
            se.EffectChainTarget3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectChainTarget3]);
            se.EffectItemType1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectItemType1]);
            se.EffectItemType2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectItemType2]);
            se.EffectItemType3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectItemType3]);
            se.EffectMiscValue1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMiscValue1]);
            se.EffectMiscValue2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMiscValue2]);
            se.EffectMiscValue3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectMiscValue3]);
            se.EffectTriggerSpell1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectTriggerSpell1]);
            se.EffectTriggerSpell2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectTriggerSpell2]);
            se.EffectTriggerSpell3 = (int)ParseOrDefault(data[(int)SpellEntryColumn.EffectTriggerSpell3]);
            se.EffectPointsPerComboPoint1 = ParseOrDefault(data[(int)SpellEntryColumn.EffectPointsPerComboPoint1]);
            se.EffectPointsPerComboPoint2 = ParseOrDefault(data[(int)SpellEntryColumn.EffectPointsPerComboPoint2]);
            se.EffectPointsPerComboPoint3 = ParseOrDefault(data[(int)SpellEntryColumn.EffectPointsPerComboPoint3]);
            se.SpellVisual = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellVisual]);
            se.SpellVisual2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellVisual2]);
            se.SpellIconID = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellIconID]);
            se.activeIconID = (int)ParseOrDefault(data[(int)SpellEntryColumn.activeIconID]);
            se.spellPriority = (int)ParseOrDefault(data[(int)SpellEntryColumn.spellPriority]);
            se.SpellName1 = data[(int)SpellEntryColumn.SpellName1];
            se.SpellName2 = data[(int)SpellEntryColumn.SpellName2];
            se.SpellName3 = data[(int)SpellEntryColumn.SpellName3];
            se.SpellName4 = data[(int)SpellEntryColumn.SpellName4];
            se.SpellName5 = data[(int)SpellEntryColumn.SpellName5];
            se.SpellName6 = data[(int)SpellEntryColumn.SpellName6];
            se.SpellName7 = data[(int)SpellEntryColumn.SpellName7];
            se.SpellName8 = data[(int)SpellEntryColumn.SpellName8];
            se.SpellNameFlag = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellNameFlag]);
            se.Rank1 = data[(int)SpellEntryColumn.Rank1];
            se.Rank2 = data[(int)SpellEntryColumn.Rank2];
            se.Rank3 = data[(int)SpellEntryColumn.Rank3];
            se.Rank4 = data[(int)SpellEntryColumn.Rank4];
            se.Rank5 = data[(int)SpellEntryColumn.Rank5];
            se.Rank6 = data[(int)SpellEntryColumn.Rank6];
            se.Rank7 = data[(int)SpellEntryColumn.Rank7];
            se.Rank8 = data[(int)SpellEntryColumn.Rank8];
            se.RankFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.RankFlags]);
            se.Description1 = data[(int)SpellEntryColumn.Description1];
            se.Description2 = data[(int)SpellEntryColumn.Description2];
            se.Description3 = data[(int)SpellEntryColumn.Description3];
            se.Description4 = data[(int)SpellEntryColumn.Description4];
            se.Description5 = data[(int)SpellEntryColumn.Description5];
            se.Description6 = data[(int)SpellEntryColumn.Description6];
            se.Description7 = data[(int)SpellEntryColumn.Description7];
            se.Description8 = data[(int)SpellEntryColumn.Description8];
            se.DescriptionFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.DescriptionFlags]);
            se.ToolTip1 = data[(int)SpellEntryColumn.ToolTip1];
            se.ToolTip2 = data[(int)SpellEntryColumn.ToolTip2];
            se.ToolTip3 = data[(int)SpellEntryColumn.ToolTip3];
            se.ToolTip4 = data[(int)SpellEntryColumn.ToolTip4];
            se.ToolTip5 = data[(int)SpellEntryColumn.ToolTip5];
            se.ToolTip6 = data[(int)SpellEntryColumn.ToolTip6];
            se.ToolTip7 = data[(int)SpellEntryColumn.ToolTip7];
            se.ToolTip8 = data[(int)SpellEntryColumn.ToolTip8];
            se.ToolTipFlags = (int)ParseOrDefault(data[(int)SpellEntryColumn.ToolTipFlags]);
            se.ManaCostPercentage = (int)ParseOrDefault(data[(int)SpellEntryColumn.ManaCostPercentage]);
            se.StartRecoveryCategory = (int)ParseOrDefault(data[(int)SpellEntryColumn.StartRecoveryCategory]);
            se.StartRecoveryTime = (int)ParseOrDefault(data[(int)SpellEntryColumn.StartRecoveryTime]);
            se.MaxTargetLevel = (int)ParseOrDefault(data[(int)SpellEntryColumn.MaxTargetLevel]);
            se.SpellFamilyName = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellFamilyName]);
            se.SpellFamilyFlags1 = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellFamilyFlags1]);
            se.SpellFamilyFlags2 = (int)ParseOrDefault(data[(int)SpellEntryColumn.SpellFamilyFlags2]);
            se.MaxAffectedTargets = (int)ParseOrDefault(data[(int)SpellEntryColumn.MaxAffectedTargets]);
            se.DmgClass = (int)ParseOrDefault(data[(int)SpellEntryColumn.DmgClass]);
            se.PreventionType = (int)ParseOrDefault(data[(int)SpellEntryColumn.PreventionType]);
            se.StanceBarOrder = (int)ParseOrDefault(data[(int)SpellEntryColumn.StanceBarOrder]);
            se.DmgMultiplier1 = ParseOrDefault(data[(int)SpellEntryColumn.DmgMultiplier1]);
            se.DmgMultiplier2 = ParseOrDefault(data[(int)SpellEntryColumn.DmgMultiplier2]);
            se.DmgMultiplier3 = ParseOrDefault(data[(int)SpellEntryColumn.DmgMultiplier3]);
            se.MinFactionId = (int)ParseOrDefault(data[(int)SpellEntryColumn.MinFactionId]);
            se.MinReputation = (int)ParseOrDefault(data[(int)SpellEntryColumn.MinReputation]);
            se.RequiredAuraVision = (int)ParseOrDefault(data[(int)SpellEntryColumn.RequiredAuraVision]);
            return se;
        }

        public enum SpellEntryColumn
        {
            Id,
            School,
            Category,
            castUI,
            Dispel,
            Mechanic,
            Attributes,
            AttributesEx,
            AttributesEx2,
            AttributesEx3,
            AttributesEx4,
            Stances,
            StancesNot,
            Targets,
            TargetCreatureType,
            RequiresSpellFocus,
            CasterAuraState,
            TargetAuraState,
            CastingTimeIndex,
            RecoveryTime,
            CategoryRecoveryTime,
            InterruptFlags,
            AuraInterruptFlags,
            ChannelInterruptFlags,
            procFlags,
            procChance,
            procCharges,
            maxLevel,
            baseLevel,
            spellLevel,
            DurationIndex,
            powerType,
            manaCost,
            manaCostPerlevel,
            manaPerSecond,
            manaPerSecondPerLevel,
            rangeIndex,
            speed,
            modalNextSpell,
            StackAmount,
            Totem1,
            Totem2,
            Reagent1,
            Reagent2,
            Reagent3,
            Reagent4,
            Reagent5,
            Reagent6,
            Reagent7,
            Reagent8,
            ReagentCount1,
            ReagentCount2,
            ReagentCount3,
            ReagentCount4,
            ReagentCount5,
            ReagentCount6,
            ReagentCount7,
            ReagentCount8,
            EquippedItemClass,
            EquippedItemSubClassMask,
            EquippedItemInventoryTypeMask,
            Effect1,
            Effect2,
            Effect3,
            EffectDieSides1,
            EffectDieSides2,
            EffectDieSides3,
            EffectBaseDice1,
            EffectBaseDice2,
            EffectBaseDice3,
            EffectDicePerLevel1,
            EffectDicePerLevel2,
            EffectDicePerLevel3,
            EffectRealPointsPerLevel1,
            EffectRealPointsPerLevel2,
            EffectRealPointsPerLevel3,
            EffectBasePoints1,
            EffectBasePoints2,
            EffectBasePoints3,
            EffectMechanic1,
            EffectMechanic2,
            EffectMechanic3,
            EffectImplicitTargetA1,
            EffectImplicitTargetA2,
            EffectImplicitTargetA3,
            EffectImplicitTargetB1,
            EffectImplicitTargetB2,
            EffectImplicitTargetB3,
            EffectRadiusIndex1,
            EffectRadiusIndex2,
            EffectRadiusIndex3,
            EffectApplyAuraName1,
            EffectApplyAuraName2,
            EffectApplyAuraName3,
            EffectAmplitude1,
            EffectAmplitude2,
            EffectAmplitude3,
            EffectMultipleValue1,
            EffectMultipleValue2,
            EffectMultipleValue3,
            EffectChainTarget1,
            EffectChainTarget2,
            EffectChainTarget3,
            EffectItemType1,
            EffectItemType2,
            EffectItemType3,
            EffectMiscValue1,
            EffectMiscValue2,
            EffectMiscValue3,
            EffectTriggerSpell1,
            EffectTriggerSpell2,
            EffectTriggerSpell3,
            EffectPointsPerComboPoint1,
            EffectPointsPerComboPoint2,
            EffectPointsPerComboPoint3,
            SpellVisual,
            SpellVisual2,
            SpellIconID,
            activeIconID,
            spellPriority,
            SpellName1,
            SpellName2,
            SpellName3,
            SpellName4,
            SpellName5,
            SpellName6,
            SpellName7,
            SpellName8,
            SpellNameFlag,
            Rank1,
            Rank2,
            Rank3,
            Rank4,
            Rank5,
            Rank6,
            Rank7,
            Rank8,
            RankFlags,
            Description1,
            Description2,
            Description3,
            Description4,
            Description5,
            Description6,
            Description7,
            Description8,
            DescriptionFlags,
            ToolTip1,
            ToolTip2,
            ToolTip3,
            ToolTip4,
            ToolTip5,
            ToolTip6,
            ToolTip7,
            ToolTip8,
            ToolTipFlags,
            ManaCostPercentage,
            StartRecoveryCategory,
            StartRecoveryTime,
            MaxTargetLevel,
            SpellFamilyName,
            SpellFamilyFlags1,
            SpellFamilyFlags2,
            MaxAffectedTargets,
            DmgClass,
            PreventionType,
            StanceBarOrder,
            DmgMultiplier1,
            DmgMultiplier2,
            DmgMultiplier3,
            MinFactionId,
            MinReputation,
            RequiredAuraVision,
        }

        public enum CreatureTemplateColumn
        {
            entry,
            KillCredit1,
            KillCredit2,
            modelid_1,
            modelid_2,
            name,
            subname,
            gossip_menu_id,
            minlevel,
            maxlevel,
            minhealth,
            maxhealth,
            minmana,
            maxmana,
            armor,
            faction_A,
            faction_H,
            npcflag,
            speed_walk,
            speed_run,
            scale,
            rank,
            mindmg,
            maxdmg,
            dmgschool,
            attackpower,
            dmg_multiplier,
            baseattacktime,
            rangeattacktime,
            unit_class,
            unit_flags,
            dynamicflags,
            family,
            trainer_type,
            trainer_spell,
            trainer_class,
            trainer_race,
            minrangedmg,
            maxrangedmg,
            rangedattackpower,
            type,
            type_flags,
            lootid,
            pickpocketloot,
            skinloot,
            resistance1,
            resistance2,
            resistance3,
            resistance4,
            resistance5,
            resistance6,
            spell1,
            spell2,
            spell3,
            spell4,
            PetSpellDataId,
            mingold,
            maxgold,
            AIName,
            MovementType,
            InhabitType,
            Civilian,
            RacialLeader,
            RegenHealth,
            equipment_id,
            trainer_id,
            vendor_id,
            mechanic_immune_mask,
            flags_extra,
            ScriptName
        }

        public enum ItemTemplateColumn
        {
            entry,
            classID,
            subclass,
            name,
            displayid,
            Quality,
            Flags,
            BuyCount,
            BuyPrice,
            SellPrice,
            InventoryType,
            AllowableClass,
            AllowableRace,
            ItemLevel,
            RequiredLevel,
            RequiredSkill,
            RequiredSkillRank,
            requiredspell,
            requiredhonorrank,
            RequiredCityRank,
            RequiredReputationFaction,
            RequiredReputationRank,
            maxcount,
            stackable,
            ContainerSlots,
            stat_type1,
            stat_value1,
            stat_type2,
            stat_value2,
            stat_type3,
            stat_value3,
            stat_type4,
            stat_value4,
            stat_type5,
            stat_value5,
            stat_type6,
            stat_value6,
            stat_type7,
            stat_value7,
            stat_type8,
            stat_value8,
            stat_type9,
            stat_value9,
            stat_type10,
            stat_value10,
            dmg_min1,
            dmg_max1,
            dmg_type1,
            dmg_min2,
            dmg_max2,
            dmg_type2,
            dmg_min3,
            dmg_max3,
            dmg_type3,
            dmg_min4,
            dmg_max4,
            dmg_type4,
            dmg_min5,
            dmg_max5,
            dmg_type5,
            armor,
            holy_res,
            fire_res,
            nature_res,
            frost_res,
            shadow_res,
            arcane_res,
            delay,
            ammo_type,
            RangedModRange,
            spellid_1,
            spelltrigger_1,
            spellcharges_1,
            spellppmRate_1,
            spellcooldown_1,
            spellcategory_1,
            spellcategorycooldown_1,
            spellid_2,
            spelltrigger_2,
            spellcharges_2,
            spellppmRate_2,
            spellcooldown_2,
            spellcategory_2,
            spellcategorycooldown_2,
            spellid_3,
            spelltrigger_3,
            spellcharges_3,
            spellppmRate_3,
            spellcooldown_3,
            spellcategory_3,
            spellcategorycooldown_3,
            spellid_4,
            spelltrigger_4,
            spellcharges_4,
            spellppmRate_4,
            spellcooldown_4,
            spellcategory_4,
            spellcategorycooldown_4,
            spellid_5,
            spelltrigger_5,
            spellcharges_5,
            spellppmRate_5,
            spellcooldown_5,
            spellcategory_5,
            spellcategorycooldown_5,
            bonding,
            description,
            PageText,
            LanguageID,
            PageMaterial,
            startquest,
            lockid,
            Material,
            sheath,
            RandomProperty,
            block,
            itemset,
            MaxDurability,
            area,
            Map,
            BagFamily,
            ScriptName,
            DisenchantID,
            FoodType,
            minMoneyLoot,
            maxMoneyLoot,
            Duration,
            ExtraFlags
        }
    }
}
