namespace Vanilla.World.Game.Entity.Object.Player
{
    using System;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Game.Entity.Tools;

    public class PlayerInfo : UnitInfo
    {
        public PlayerInfo(ObjectGUID guid, Character databaseCharacter, ChrRaces race, ChrClasses chrClass) : base(guid)
        {
            this.Class = chrClass;
            this.ClassID = this.Class.ClassID;
            this.Gender = databaseCharacter.Gender;
            this.Power = (byte)this.Class.PowerType;

            this.Race = race;
            this.RaceID = race.RaceID;
            this.FactionTemplate = race.FactionID;
            this.DisplayID = this.NativeDisplayID = (int)(this.Gender == 0 ? race.ModelM : race.ModelF);
            this.Health = (int)databaseCharacter.Health;

            //Level = databaseCharacter.Level;
            this.XP = (int)databaseCharacter.XP;
            this.NextLevelXP = 400;

            Byte[] playerBytes = BitConverter.GetBytes(databaseCharacter.PlayerBytes);
            Byte[] playerBytes2 = BitConverter.GetBytes(databaseCharacter.PlayerBytes2);

            this.Skin = playerBytes[0];
            this.Face = playerBytes[1];
            this.HairStyle = playerBytes[2];
            this.HairColor = playerBytes[3];
            this.Accessory = playerBytes2[0];

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
    }
}
