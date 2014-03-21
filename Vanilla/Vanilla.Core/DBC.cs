using Vanilla.Character.Database;

namespace Vanilla.Core
{
    using System.Collections.Generic;
    using Vanilla.Core.Constants.Character;

    public struct GenderModelEntry
    {
        public int Male;
        public int Female;

        public GenderModelEntry(int male, int female)
        {
            this.Male = male;
            this.Female = female;
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

        //This shouldnt be here!!! Refactor later. Core should not need to reference database!
        public static int GetModel(character character)
        {
            return character.gender == (byte)Gender.Male ? (byte)MODELS[(RaceID)character.race].Male : (byte)MODELS[(RaceID)character.race].Female;
        }
    }
}
