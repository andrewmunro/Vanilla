﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Tools.DBC.Tables;
using SQLite;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Tools.DBC
{
    public class DBCConverter
    {
        public static string DBC_LOCATION = @"C:\Dropbox\Vanilla\dbc\";

        public static SQLiteConnection SQLite;

        public static void Convert()
        {
            SQLite = new SQLiteConnection("dbc.db3");

            List<string> DBCFiles = Directory.GetFiles(DBC_LOCATION, "*.csv").ToList<string>();

            //GenerateTable<ChrRacesEntry>(CSVToChrRacesEntry, DBC_LOCATION + "ChrRaces.dbc.CSV");
            //GenerateTable<EmotesTextEntry>(CSVToEmotesTextEntry, DBC_LOCATION + "EmotesText.dbc.CSV");
            //GenerateTable<AreaTableEntry>(CSVToAreaTableEntry, DBC_LOCATION + "AreaTable.dbc.CSV");
            //GenerateTable<AreaTriggerEntry>(CSVToAreaTriggerEntry, DBC_LOCATION + "AreaTrigger.dbc.CSV");
            //GenerateTable<SpellEntry>(CSVToSpellEntry, DBC_LOCATION + "Spell.csv");
            GenerateTable<CharStartOutfitEntry>(CSVToCharStartOutfitEntry, DBC_LOCATION + "CharStartOutfit.csv");

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


        private static CharStartOutfitEntry CSVToCharStartOutfitEntry(string[] data)
        {
            uint RaceClassGender = uint.Parse(data[1]);

            string[] itemID = new string[12];
            for (int index = 0; index < 12; index++)
            {
                itemID[index] = int.Parse(data[index + 2]).ToString();
            }

            string itemSCV = string.Join(",", itemID);
            

            CharStartOutfitEntry BLA = new CharStartOutfitEntry()
            {
                Race = (RaceID)(RaceClassGender >> 8),
                Class = (ClassID)(RaceClassGender >> 12),
                Gender = (Gender)(RaceClassGender >> 18),
                ItemIDCSV = itemSCV
            };

            Console.WriteLine(BLA.Race);

            return BLA;
        }
    }
}
