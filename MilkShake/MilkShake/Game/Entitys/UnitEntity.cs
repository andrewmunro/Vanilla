using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Constants.Game.World.Entity;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Game.Entitys
{
    public class UnitEntity : ObjectEntity
    {
        public UnitEntity() : base(ObjectGUID.GetUnitGUID(), (int)EUnitFields.UNIT_END - 0x4)
        {
            //SetUpdateField<Int32>((int)EObjectFields.OBJECT_FIELD_GUID, GUID.Low);

            SetUpdateField<byte>((int)EObjectFields.OBJECT_FIELD_TYPE, (byte)25);


            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_POWER1, 1000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER1, 1000);


            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXPOWER2, 1000);

            //ChrRacesEntry Race = DBC.ChrRaces.List.Find(r => (RaceID)r.RaceID == character.Race);


            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, Race.FactionID);
            //SetUpdateField<Int32>((int)EUnitFields, Race.FactionID);

            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BYTES_0, 16777477); // Unsure
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)RaceID.Dwarf, 0);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)ClassID.Warlock, 1);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)Gender.Male, 2);
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, 0, 3); //POwer 1 = rage

            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_FLAGS, 0x00000010);
            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURA, 2457);
            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURAFLAGS, 9);
            //SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_AURALEVELS, 1);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_BASEATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_OFFHANDATTACKTIME, 2000);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_RANGEDATTACKTIME, 2000);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_DISPLAYID, 114);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, 114);

            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MINDAMAGE, 1083927991);
            SetUpdateField<Int32>((int)EUnitFields.UNIT_FIELD_MAXDAMAGE, 1086025143);

            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, (byte)UnitStandStateType.UNIT_STAND_STATE_STAND, 0); // Stand State?
            SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, 0xEE, 1); //  if (getPowerType() == POWER_RAGE || getPowerType() == POWER_MANA)
            //SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_1, (character.Class == ClassID.Warrior) ? (byte)ShapeshiftForm.FORM_BATTLESTANCE : (byte)ShapeshiftForm.FORM_NONE, 2); // ShapeshiftForm?
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
        }

    }
}
