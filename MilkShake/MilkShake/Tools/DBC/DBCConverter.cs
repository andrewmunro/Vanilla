using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Tools.DBC.Tables;
using SQLite;

namespace Milkshake.Tools.DBC
{
    public class DBCConverter
    {
        public static string DBC_LOCATION = @"C:\Users\Andrew\Documents\My Dropbox\Projects\Vanilla\dbc\";

        public static SQLiteConnection SQLite;

        public static void Convert()
        {
            SQLite = new SQLiteConnection("dbc.db3");

            List<string> DBCFiles = Directory.GetFiles(DBC_LOCATION, "*.csv").ToList<string>();

            //GenerateTable<ChrRacesEntry>(CSVToChrRacesEntry, DBC_LOCATION + "ChrRaces.csv");
            //GenerateTable<EmotesTextEntry>(CSVToEmotesTextEntry, DBC_LOCATION + "EmotesText.csv");
            //GenerateTable<AreaTableEntry>(CSVToAreaTableEntry, DBC_LOCATION + "AreaTable.csv");
            //GenerateTable<AreaTriggerEntry>(CSVToAreaTriggerEntry, DBC_LOCATION + "AreaTrigger.csv");
            //GenerateTable<SpellEntry>(CSVToSpellEntry, DBC_LOCATION + "Spell.csv");
            //GenerateTable<ChrStartingOutfitEntry>(CSVToChrStartingEntry, DBC_LOCATION + "CharStartOutfit.csv");
            //GenerateTable<ItemTemplateEntry>(CSVToChrItemTemplateEntry, DBC_LOCATION + "item_template.csv");

            Console.Write(true);
            Console.Read();
        }

        public static void GenerateTable<T>(Func<string[], T> Converter, string url)
        {
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
            Log.Print(LogType.Debug, "Adding " + ConvertedEntries.Count + " entries");
        }

        public static List<T> Convert<T>(Func<string[], T> converter, string url)
        {
            List<string> csvEntrys = File.ReadAllLines(url).ToList<string>();

            List<T> convertedEntrys = new List<T>();

            
            
            csvEntrys.ForEach(e =>
                {
                    

                    
                    try
                    {
                        convertedEntrys.Add(converter(e.Split(',')));
                    }
                    catch (Exception ed)
                    {
                    }
                }
            );

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
                TextID = int.Parse(data[2]),
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


        private static SpellEntry CSVToSpellEntry(string[] data)
        {
            return new SpellEntry()
            {
                ID = int.Parse(data[0]),
                School = int.Parse(data[1]),
                Category = int.Parse(data[2]),
                Name = data[120].Replace("\"", ""),
                Cooldown = int.Parse(data[19]),
                CooldownCatagory = int.Parse(data[20]),
                Speed = float.Parse(data[37])
            };
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
