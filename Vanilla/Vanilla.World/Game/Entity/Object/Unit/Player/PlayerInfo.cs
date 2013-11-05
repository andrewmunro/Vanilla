namespace Vanilla.World.Game.Entity.Object.Unit.Player
{
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Database.Character.Models;

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
        }

        public ChrClasses Class { get; set; }

        public ChrRaces Race { get; set; }

        [UpdateField(EUnitFields.PLAYER_XP)]
        public int XP { get; set; }

        [UpdateField(EUnitFields.PLAYER_NEXT_LEVEL_XP)]
        public int NextLevelXP { get; set; }
    }
}
