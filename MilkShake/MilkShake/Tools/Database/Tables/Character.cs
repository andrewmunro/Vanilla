using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int GUID { get; set; }

        public int AccountID { get; set; }
        public string Name { get; set; }

        public RaceID Race { get; set; }
        public ClassID Class { get; set; }

        public byte Level { get; set; }
        public int Money { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Rage { get; set; }
        public int Focus { get; set; }
        public int Energy { get; set; }
        public int Happiness { get; set; }
        public byte Drunk { get; set; }
        public byte Online { get; set; }
        public uint Flags { get; set; }

        public int MapID { get; set; }
        public int Zone { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Rotation { get; set; }

        public Gender Gender { get; set; }
        public byte Skin { get; set; }
        public byte Face { get; set; }
        public byte HairStyle { get; set; }
        public byte HairColor { get; set; }
        public byte Accessory { get; set; }

        public string Equipment { get; set; }

        public string Faction
        {
            //Temporary hack to get faction
            get
            {
                if (Race == RaceID.Human ||
                    Race == RaceID.Dwarf ||
                    Race == RaceID.Gnome ||
                    Race == RaceID.NightElf)
                    return "Alliance";
                return "Horde";
            }
        }
    }
}
