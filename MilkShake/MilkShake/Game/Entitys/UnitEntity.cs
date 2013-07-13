using System;
using Milkshake.Game.Constants.Game.Update;
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

        public override string Name
        {
            get { return Template.name; }
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
                
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, template.maxlevel);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, entry.modelid);
            }
        }
    }
}