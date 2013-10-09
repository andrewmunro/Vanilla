namespace Vanilla.World.Game.Entitys
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Vanilla.Core;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Game.Constants.Game.Update;
    using Vanilla.World.Game.Constants.Game.World.Entity;
    using Vanilla.World.Game.Managers;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.DBC;
    using Vanilla.World.Tools.DBC.Tables;
    using Vanilla.World.Tools.Shared;

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
                WorldSession session = WorldServer.Sessions.Find(s => Utils.Distance(s.Entity.X, s.Entity.Y, Entity.X, Entity.Y) < 30);

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

        public int DisplayID
        {
            get { return (int)UpdateData[(int)EUnitFields.UNIT_FIELD_DISPLAYID]; }
            set { SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_DISPLAYID, value); }
        }

        public Creature Creature;

        public CreatureTemplateEntry Template;

        public UnitEntity(ObjectGUID objectGUID)
            : base(objectGUID)
        {
        }

        public UnitEntity(Creature creature, ObjectGUID guid = null) : base(guid ?? ObjectGUID.GetUnitGUID((uint)creature.GUID))
        {
            new AIBrain(this);

            Creature = creature;

            CreatureTemplateEntry template = DBC.CreatureTemplates.Find(a => a.entry == creature.ID);

            Template = template;

            Type = 0x9;
            Entry = (byte)template.entry;

            X = creature.PositionX;
            Y = creature.PositionY;
            Z = creature.PositionZ;
            R = creature.Orientation;

            SetUpdateField<int>((int)EUnitFields.UNIT_NPC_FLAGS, template.npcflag);
            SetUpdateField<int>((int)EUnitFields.UNIT_DYNAMIC_FLAGS, template.dynamicflags);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FLAGS, template.unit_flags);

            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_FACTIONTEMPLATE, template.faction_A);

            SetUpdateField<long>((int)EUnitFields.UNIT_FIELD_HEALTH, creature.Curhealth); //May need casting to int.
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_MAXHEALTH, template.maxhealth);
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_LEVEL, template.maxlevel);
            DisplayID = creature.ModelID;

            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_CREATEDBY, 0);
            
        }

        public void SetStandState(UnitStandStateType state)
        {
            SetUpdateField<int>((int)EUnitFields.UNIT_FIELD_BYTES_1, (byte)state, 0);

            if(this is PlayerEntity)
            {
                ServerPacket packet = new ServerPacket(WorldOpcodes.SMSG_STANDSTATE_UPDATE);
                packet.Write((byte)state);
                (this as PlayerEntity).Session.SendPacket(packet);
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
                    if(session != null) session.SendPacket(new PSEmote((uint)emoteID, session.Character.GUID));
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

            World.PlayersWhoKnowUnit(this).ForEach(e => e.Session.SendPacket(packet));

            X = targetX;
            Y = targetY;
            Z = targetZ;
        }
    }
}