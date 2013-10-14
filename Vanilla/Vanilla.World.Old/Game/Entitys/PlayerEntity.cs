namespace Vanilla.World.Game.Entitys
{
    using System;
    using System.Collections.Generic;
    using Character.Database.Models;
    using Vanilla.Core;
    using Vanilla.Core.Constants.Character;
    using Vanilla.World.Communication.Outgoing.Players;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game.Constants.Game.Update;
    using Vanilla.World.Game.Constants.Game.World.Entity;
    using Vanilla.World.Game.Spells;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.DBC;
    using Vanilla.World.Tools.DBC.Tables;
    using Vanilla.World.Tools.Shared;

    public class PlayerEntity : UnitEntity
    {
        public List<ObjectEntity> OutOfRangeEntitys { get; private set; }

        public List<UpdateBlock> UpdateBlocks { get; private set; }

        public List<PlayerEntity> KnownPlayers { get; private set; }

        public List<UnitEntity> KnownUnits { get; private set; }

        public List<GOEntity> KnownGameObjects { get; private set; }

        public Character Character;

        public UnitEntity Target;

        public float LastUpdateX;

        public float LastUpdateY;

        public float X, Y, Z;

        public override string Name
        {
            get
            {
                return Character.Name;
            }
        }

        public int XP
        {
            get { return (int)UpdateData[(int)EUnitFields.PLAYER_XP]; }
            set { SetUpdateField<int>((int)EUnitFields.PLAYER_XP, value); }
        }

        public override int DataLength
        {
            get { return (int)EUnitFields.PLAYER_END - 0x4; }
        }

        public PlayerEntity(Character character) : base(new ObjectGUID((uint)character.GUID, TypeID.TYPEID_PLAYER, HighGUID.HIGHGUID_MO_TRANSPORT))
        {
            Character = character;
            KnownPlayers = new List<PlayerEntity>();
            KnownUnits = new List<UnitEntity>();
            KnownGameObjects = new List<GOEntity>();

            //TODO Fix spellCollection DBC
            //SpellCollection = new SpellCollection(this);

            GUID = (uint)character.GUID;
            //SetUpdateField<Int32>((int)EObjectFields.OBJECT_FIELD_GUID, character.GUID);

            SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_TYPE, (byte)25);
            //SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_TYPE, (byte)TypeID.TYPEID_UNIT);

            OutOfRangeEntitys = new List<ObjectEntity>();
            UpdateBlocks = new List<UpdateBlock>();

            Character = character;
            //Type = (byte)25;
            Health = 70;
            MaxHealth = 70;
            Level = 1;
            XP = 0;
            Scale = 1;

            ChrRacesEntry Race = DBC.ChrRaces.List.Find(r => (RaceID)r.RaceID == character.Race);            
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, Race.FactionID);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_POWER1, 1000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER1, 1000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER2, 1000);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Race, 0);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Class, 1);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Gender, 2);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, 0, 3); //POwer 1 = rage
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BASEATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_OFFHANDATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RANGEDATTACKTIME, 2000);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_DISPLAYID, DBCTemp.GetModel(character));
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, DBCTemp.GetModel(character));

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MINDAMAGE, 1083927991);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXDAMAGE, 1086025143);

            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, (byte)UnitStandStateType.UNIT_STAND_STATE_STAND, 0); // Stand State?
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, 0xEE, 1); //  if (getPowerType() == POWER_RAGE || getPowerType() == POWER_MANA)
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, (character.Class == ClassID.Warrior) ? (byte)ShapeshiftForm.FORM_BATTLESTANCE : (byte)ShapeshiftForm.FORM_NONE, 2); // ShapeshiftForm?
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, /* (byte)UnitBytes1_Flags.UNIT_BYTE1_FLAG_ALL */ 0, 3); // StandMiscFlags

            SetUpdateField<float>((int)EUnitFields.UNIT_MOD_CAST_SPEED, 1);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT0, 22);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT1, 18);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT2, 23);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT3, 18);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT4, 25);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RESISTANCES, 36);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RESISTANCES_05, 10);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BASE_HEALTH, 20);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_ATTACK_POWER, 27);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER, 9);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MINRANGEDDAMAGE, 1074940196);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXRANGEDDAMAGE, 1079134500);


            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.Skin, 0);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.Face, 1);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.HairStyle, 2);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.HairColor, 3);

            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES_2, character.Accessory, 0);

            ItemTemplateEntry[] displayItems = DBC.ItemTemplates.GenerateInventoryByIDs(Utils.CSVStringToIntArray(character.Equipment));

            for (byte index = 0; index < 19; index++)
            {
                ItemTemplateEntry entry = displayItems[index];

                if (entry != null)
                {
                    int visualBase = (int)EUnitFields.PLAYER_VISIBLE_ITEM_1_0 + (index * 12);
                    SetUpdateField<byte>((int)visualBase, (byte)displayItems[index].entry);
                }
            }

            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES_2, character.Accessory, 0);

            SetUpdateField<Int32>((int)EUnitFields.PLAYER_NEXT_LEVEL_XP, 400);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_SKILL_INFO_1_1, 26); 
            // sdfs
            SetUpdateField<Int32>((int)719, 65537);
            SetUpdateField<Int32>((int)721, 43);
            SetUpdateField<Int32>((int)722, 327681);
            SetUpdateField<Int32>((int)724, 55);
            SetUpdateField<Int32>((int)725, 327681);
            SetUpdateField<Int32>((int)727, 95);
            SetUpdateField<Int32>((int)728, 327681);
            SetUpdateField<Int32>((int)730, 109);
            SetUpdateField<Int32>((int)731, 19661100);
            SetUpdateField<Int32>((int)733, 162);
            SetUpdateField<Int32>((int)734, 327681);
            SetUpdateField<Int32>((int)736, 173);
            SetUpdateField<Int32>((int)737, 327681);
            SetUpdateField<Int32>((int)739, 413);
            SetUpdateField<Int32>((int)740, 65537);
            SetUpdateField<Int32>((int)742, 414);
            SetUpdateField<Int32>((int)743, 65537);
            SetUpdateField<Int32>((int)745, 415);
            SetUpdateField<Int32>((int)746, 65537);
            SetUpdateField<Int32>((int)748, 433);
            SetUpdateField<Int32>((int)749, 65537);
            SetUpdateField<Int32>((int)751, 673);
            SetUpdateField<Int32>((int)752, 19661100);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_CHARACTER_POINTS2, 2);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_BLOCK_PERCENTAGE, 1083892040);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_DODGE_PERCENTAGE, 1060991140);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_CRIT_PERCENTAGE, 1060991140);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_RANGED_CRIT_PERCENTAGE, 1060320051);
            SetUpdateField<Int32>((int)1192, 10);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_FIELD_MOD_DAMAGE_DONE_PCT, 1065353216);
            SetUpdateField<Int32>((int)1216, 1065353216);
            SetUpdateField<Int32>((int)1217, 1065353216);
            SetUpdateField<Int32>((int)1218, 1065353216);
            SetUpdateField<Int32>((int)1219, 1065353216);
            SetUpdateField<Int32>((int)1220, 1065353216);
            SetUpdateField<Int32>((int)1221, 1065353216);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_FIELD_WATCHED_FACTION_INDEX, -1);
            SetUpdateField<Int32>((int)EUnitFields.PLAYER_FIELD_COINAGE, character.Money);
        }


        public SpellCollection SpellCollection { get; private set; }

        public WorldSession Session { get; set; }

        public void TeleportTo(long mapID, float x, float y, float z, float r = 0)
        {
            if (Character.Map != mapID)
            {
                Session.SendPacket(new PSTransferPending((int)mapID));
            }

            Character.Map = mapID;
            Character.PositionX = x;
            Character.PositionY = y;
            Character.PositionZ = z;
            Character.Orientation = r;
            VanillaWorld.CharacterDatabase.SaveChanges();

            Session.SendPacket(new PSNewWorld((int)mapID, x, y, z, r));
        }
    }
}
