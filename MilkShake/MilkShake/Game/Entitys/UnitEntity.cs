using System;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Net;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Game.Managers;

namespace Milkshake.Game.Entitys
{
    public class UnitEntity : ObjectEntity, ILocation
    {
        public float X, Y, Z, R;

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

        public UnitEntity(CreatureEntry entry = null) : base(ObjectGUID.GetUnitGUID())
        {
            if (entry == null)
            {
                Type = 9;
                Entry = 68;
                //Data = -248512512;

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

                ObjectGUID = Entitys.ObjectGUID.GetUnitGUID((uint)entry.guid);
                GUID = ObjectGUID.RawGUID;

                Type = (byte)0x9;
                Entry = (byte)template.entry;
                //Data = -248512512;

                X = entry.position_x;
                Y = entry.position_y;
                Z = entry.position_z;
                R = entry.orientation;

                SetUpdateField<int>((int)EUnitFields.UNIT_NPC_FLAGS, template.npcflag);
                SetUpdateField<int>((int)EUnitFields.UNIT_DYNAMIC_FLAGS, template.dynamicflags);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FLAGS, template.unit_flags);

                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, template.faction_A);
                
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, template.maxlevel);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, entry.modelid);
            }
        }

/*        public void PlayEmote(Emote emoteID)
        {
            if (emoteID == 0) EmoteState = (int)emoteID;
            else
            {
                EmotesEntry emote = DBC.Emotes.List.Find(e => e.ID == (int)emoteID);
                if (emote.EmoteType == 0) EmoteState = (int)emoteID;
                else
                {
                    WorldSession session = (this as PlayerEntity).Session;
                    if(session != null) session.sendPacket(new PSEmote((uint)emoteID, session.Character.GUID));
                }
            }
        }*/
    }
}