using System;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools;

namespace Milkshake.Game.Entitys
{

    public class PlayerEntity : WorldEntity
    {
        public PlayerEntity(Character character) : base((int)EUnitFields.PLAYER_END - 0x4)
        {
            SetUpdateField<Int32>((int)EObjectFields.OBJECT_FIELD_GUID, character.GUID);

            SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_TYPE, (byte)25);
            SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)1f);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_HEALTH, 70);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_POWER4, 100);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, 70);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER2, 1000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER4, 100);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_LEVEL, 1);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, 5);

            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BYTES_0, 16777477); // Unsure
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Race, 0);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Class, 1);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)character.Gender, 2);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, 1, 3); //POwer

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_FLAGS, 8);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURA, 2457);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURAFLAGS, 9);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURALEVELS, 1);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BASEATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_OFFHANDATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RANGEDATTACKTIME, 2000);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_DISPLAYID, DBCTemp.GetModel(character));
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, DBCTemp.GetModel(character));

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MINDAMAGE, 1083927991);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXDAMAGE, 1086025143);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BYTES_1, 1175040);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_MOD_CAST_SPEED, 1065353216);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT0, 22);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT1, 18);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT2, 23);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT3, 18);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_STAT4, 25);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RESISTANCES, 36);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RESISTANCES_05, 10);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BASE_HEALTH, 20);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BYTES_2, 10240);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_ATTACK_POWER, 27);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RANGED_ATTACK_POWER, 9);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MINRANGEDDAMAGE, 1074940196);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXRANGEDDAMAGE, 1079134500);


            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.Skin, 0);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.Face, 1);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.HairStyle, 2);
            SetUpdateField<byte>((int)EUnitFields.PLAYER_BYTES, character.HairColor, 3);

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


            
        }
    }
}
