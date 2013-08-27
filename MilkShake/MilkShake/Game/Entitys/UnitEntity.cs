using System;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Net;
using Milkshake.Tools;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Game.Managers;
using Milkshake.Network;
using Milkshake.Communication;
using Milkshake.Tools.Extensions;
using System.Collections.Generic;
using System.Threading;

namespace Milkshake.Game.Entitys
{
    public class AIBrainManager
    {
        public static List<AIBrain> AIBrains = new List<AIBrain>();

        public static void Boot()
        {
            new Thread(UpdateThread).Start();
        }

        private static void UpdateThread()
        {
            while (true)
            {
                Update();
                Thread.Sleep(1000);
            }
        }

        private static void Update()
        {
            AIBrains.ForEach(ai => ai.Update());
        }
    }

    public class AIBrain
    {
        public PlayerEntity Target;
        public UnitEntity Entity;

        public AIBrain(UnitEntity entity)
        {
            Entity = entity;

            AIBrainManager.AIBrains.Add(this);
        }

        public void Update()
        {
            if (Target == null)
            {
                WorldSession session = WorldServer.Sessions.Find(s => Milkshake.Tools.Helper.Distance(s.Entity.X, s.Entity.Y, Entity.X, Entity.Y) < 30);

                if (session != null)
                {
                    Target = session.Entity;
                }
            }
            else
            {
                Entity.Move(Target.X, Target.Y, Target.Z);
            }
        }
    }

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


		public int Health
		{
			get { return (int)UpdateData[(int)EUnitFields.UNIT_FIELD_HEALTH]; }
			set { SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, value); }
		}

		public int MaxHealth
		{
			get { return (int)UpdateData[(int)EUnitFields.UNIT_FIELD_MAXHEALTH]; }
			set { SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, value); }
		}

		public int Level
		{
			get { return (int)UpdateData[(int)EUnitFields.UNIT_FIELD_LEVEL]; }
			set { SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, value); }
		}

		public int EmoteState
		{
			get { return (int)UpdateData[(int)EUnitFields.UNIT_NPC_EMOTESTATE]; }
			set { SetUpdateField<int>((int)EUnitFields.UNIT_NPC_EMOTESTATE, value); }
		}


        public CreatureEntry TEntry;
        public CreatureTemplateEntry Template;

        public UnitEntity(ObjectGUID objectGUID)
            : base(objectGUID)
        {
        }

        public UnitEntity(CreatureEntry entry = null) : base(ObjectGUID.GetUnitGUID())
        {
            new AIBrain(this);

            if (entry == null)
            {
                Type = 9;
                Entry = 68;

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
                
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_HEALTH, entry.curhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, template.maxhealth);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, template.maxlevel);
                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, entry.modelid);

                SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_CREATEDBY, 0);
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

        public void Move(float targetX, float targetY, float targetZ)
        {
            ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_MONSTER_MOVE);
            packet.WritePackedUInt64(ObjectGUID.RawGUID);
            packet.Write(X);
            packet.Write(Y);
            packet.Write(Z);
            packet.Write((UInt32)Environment.TickCount);
            packet.Write((byte)0); // SPLINETYPE_NORMAL
            packet.Write(0); // sPLINE FLAG
            packet.Write(500); // TIME
            packet.Write(1);
            packet.Write(targetX);
            packet.Write(targetY);
            packet.Write(targetZ);

            World.PlayersWhoKnowUnit(this).ForEach(e => e.Session.sendPacket(packet));

            X = targetX;
            Y = targetY;
            Z = targetZ;
        }
    }
}