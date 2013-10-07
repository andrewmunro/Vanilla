using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Tools
{
    public struct GenderModelEntry
    {
        public int Male;
        public int Female;

        public GenderModelEntry(int male, int female)
        {
            Male = male;
            Female = female;
        }
    }

    public class DBCTemp
    {
        private static readonly Dictionary<RaceID, GenderModelEntry> MODELS = new Dictionary<RaceID, GenderModelEntry>()
        {
            { RaceID.Human, new GenderModelEntry(49, 50) },
            { RaceID.Orc, new GenderModelEntry(51, 52) },
            { RaceID.Dwarf, new GenderModelEntry(53, 54) },
            { RaceID.NightElf, new GenderModelEntry(55, 56) },
            { RaceID.Undead, new GenderModelEntry(57, 58) },
            { RaceID.Tauren, new GenderModelEntry(59, 60) },
            { RaceID.Gnome, new GenderModelEntry(1563, 1564) },
            { RaceID.Troll, new GenderModelEntry(1478, 1479) },
        };

        public static int GetModel(Character character)
        {
            return character.Gender == Gender.Male ? MODELS[character.Race].Male : MODELS[character.Race].Female;
        }
    }
}
