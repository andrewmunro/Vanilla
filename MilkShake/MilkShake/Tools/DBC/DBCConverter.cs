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
            GenerateTable<ChrStartingOutfitEntry>(CSVToChrStartingEntry, DBC_LOCATION + "CharStartOutfit.csv");

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
    }
}
