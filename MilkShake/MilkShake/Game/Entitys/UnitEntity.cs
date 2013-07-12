using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Constants.Game.World.Entity;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Game.Managers;

namespace Milkshake.Game.Entitys
{
    public class UnitEntity : ObjectEntity, ILocation
    {
        public float X, Y, Z;

        public override int DataLength
        {
            get { return (int)EUnitFields.UNIT_END - 0x4; }
        }

        public CreatureEntry TEntry;
        public CreatureTemplateEntry Template;

        public UnitEntity(CreatureEntry entry = null) : base(ObjectGUID.GetUnitGUID((uint)entry.guid))
        {
            if (entry == null)
            {
                Type = 9;
                Entry = 68;
                Data = -248512512;

                //SetUpdateField<int>((int)EUnitFields.OBJECT_FIELD_SCALE_X, 1065353216);
                //SetUpdateField<int>((int)EUnitFields.GAMEOBJECT_LEVEL, 4667);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, 4667);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, 4667);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, 55);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, 5446);
            }
            else
            {
                TEntry = entry;
                //ObjectGUID = new Entitys.ObjectGUID(entry.guid, Constants.Game.Update.TypeID.TYPEID_UNIT, 
                CreatureTemplateEntry template = DBC.CreatureTemplates.Find(a => a.entry == entry.id);

                Template = template;

                Console.WriteLine(template.name);

                Type = (byte)template.type;
                Entry = (byte)template.entry;
                Data = -248512512;

                X = entry.position_x;
                Y = entry.position_y;
                Z = entry.position_z;

                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FLAGS, template.unit_flags);

                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, template.faction_A);
                
                

                //SetUpdateField<int>((int)EUnitFields.OBJECT_FIELD_SCALE_X, 1065353216);
                //SetUpdateField<int>((int)EUnitFields.GAMEOBJECT_LEVEL, 4667);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, template.maxlevel);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, entry.modelid);
            }
            /*
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, 11);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BYTES_0, 131328);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY, 7483);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_SLOT_DISPLAY_01, 2080);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_INFO, 33490690);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_INFO_01, 781);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_INFO_02, 234948100);
            SetUpdateField<int>((int)EUnitFields.UNIT_VIRTUAL_ITEM_INFO_03, 4);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FLAGS, 36864);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BASEATTACKTIME, 2000);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_OFFHANDATTACKTIME, 1500);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_RANGEDATTACKTIME, 2000);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BOUNDINGRADIUS, 1045757428);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_COMBATREACH, 1069547520);
            
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_NATIVEDISPLAYID, 5446);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MINDAMAGE, 1142374400);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXDAMAGE, 1143357440);
            SetUpdateField<int>((int)EUnitFields.UNIT_MOD_CAST_SPEED, 1065353216);
            SetUpdateField<int>((int)EUnitFields.UNIT_NPC_FLAGS, 1);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BASE_HEALTH, 4667);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BYTES_2, 4097);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_ATTACK_POWER, 293);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MINRANGEDDAMAGE, 1133947781);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXRANGEDDAMAGE, 1137907139);
             */
        }
    }
}