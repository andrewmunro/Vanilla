using Vanilla.Character.Database;

namespace Vanilla.World.Game.Entity.Object.Player
{
    using System;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Game.Entity.Tools;

    public class PlayerInfo : UnitInfo
    {
        public PlayerInfo(ObjectGUID guid, character databaseCharacter, ChrRaces race, ChrClasses chrClass) : base(guid)
        {
            this.Class = chrClass;
            this.ClassID = this.Class.ClassID;
            this.Gender = databaseCharacter.gender;
            this.Power = (byte)this.Class.PowerType;

            this.Race = race;
            this.RaceID = race.RaceID;
            this.FactionTemplate = race.FactionID;
            this.DisplayID = this.NativeDisplayID = (int)(this.Gender == 0 ? race.ModelM : race.ModelF);
            this.Health = (int)databaseCharacter.health;

            //Level = databaseCharacter.Level;
            this.XP = (int)databaseCharacter.xp;
            this.NextLevelXP = 400;

            Byte[] playerBytes = BitConverter.GetBytes(databaseCharacter.playerBytes);
            Byte[] playerBytes2 = BitConverter.GetBytes(databaseCharacter.playerBytes2);

            this.Skin = playerBytes[0];
            this.Face = playerBytes[1];
            this.HairStyle = playerBytes[2];
            this.HairColor = playerBytes[3];
            this.Accessory = playerBytes2[0];

            FactionTemplate = race.FactionID;
            UnitFlag = (int)UnitFlags.UNIT_FLAG_PVP;
            FlagUnk = 0x08 | 0x20;
            WatchedFactionIndex = (int)databaseCharacter.watchedFaction;


            this.Money = (int)databaseCharacter.money;

/*
            
            item_template[] equipment = ItemUtils.GenerateInventoryByIDs(Utils.CSVStringToIntArray(databaseCharacter.equipmentCache));
            VisualItems = new Item[19];
            for (byte itemSlot = 0; itemSlot < 19; itemSlot++)
            {
                if (equipment == null) return;
                if (equipment[itemSlot] != null)
                {
                    VisualItems[itemSlot] = new Item()
                                                {
                                                    Creator = guid.RawGUID,
                                                    EnchantmentIDs = new[] { 0, 0 },
                                                    Entry = equipment[itemSlot].entry,
                                                    RandomPropertyID = equipment[itemSlot].RandomProperty,
                                                    ItemSuffixFactor = 3
                                                };

                }
                else
                {
                    VisualItems[itemSlot] = new Item()
                                                {
                                                    Creator = 0,
                                                    EnchantmentIDs = new[] { 0, 0 },
                                                    Entry = 0,
                                                    RandomPropertyID = 0,
                                                    ItemSuffixFactor = 0
                                                };
                }
            }*/

            Type |= (int)TypeMask.TYPEMASK_PLAYER;
        }

        public ChrClasses Class { get; set; }

        public ChrRaces Race { get; set; }

        [UpdateField(EUnitFields.PLAYER_XP)]
        public int XP { get; set; }

        [UpdateField(EUnitFields.PLAYER_NEXT_LEVEL_XP)]
        public int NextLevelXP { get; set; }

        [UpdateField(EUnitFields.PLAYER_BYTES, true, 0)]
        public byte Skin { get; set; }

        [UpdateField(EUnitFields.PLAYER_BYTES, true, 1)]
        public byte Face { get; set; }

        [UpdateField(EUnitFields.PLAYER_BYTES, true, 2)]
        public byte HairStyle { get; set; }

        [UpdateField(EUnitFields.PLAYER_BYTES, true, 3)]
        public byte HairColor { get; set; }

        [UpdateField(EUnitFields.PLAYER_BYTES_2, true, 0)]
        public byte Accessory { get; set; }

        [UpdateField(EUnitFields.PLAYER_FIELD_COINAGE)]
        public int Money { get; set; }

        [UpdateField(EUnitFields.UNIT_FIELD_BYTES_2, true, 1)]
        public byte FlagUnk { get; set; }

        [UpdateField(EUnitFields.PLAYER_FIELD_WATCHED_FACTION_INDEX)]
        public int WatchedFactionIndex { get; set; }

/*        [UpdateField(EUnitFields.PLAYER_VISIBLE_ITEM_1_0)]
        public Item[] VisualItems { get; set; }*/
    }
}
