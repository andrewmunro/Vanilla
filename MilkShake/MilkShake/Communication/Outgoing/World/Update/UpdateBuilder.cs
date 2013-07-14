using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using System.IO;
using Milkshake.Tools.Extensions;
using Milkshake.Game.Constants.Game.Update;

namespace Milkshake.Communication.Outgoing.World.Update
{
    public abstract class UpdateBlock
    {
        public string Info { get; internal set; }
        public byte[] Data { get; internal set; }

        internal BinaryWriter Writer;

        public UpdateBlock()
        {
            Writer = new BinaryWriter(new MemoryStream());
        }

        public void Build()
        {
            BuildData();

            Data = (Writer.BaseStream as MemoryStream).ToArray();
            Info = BuildInfo();
        }

        public abstract void BuildData();
        public abstract string BuildInfo();
    }

    public class OutOfRangeBlock : UpdateBlock
    {
        public List<ObjectEntity> Entitys;

        public OutOfRangeBlock(List<ObjectEntity> entitys) : base()
        {
            Entitys = entitys;

            Build(); // ):
        }

        public override void BuildData()
        {
            Writer.Write((byte)ObjectUpdateType.UPDATETYPE_OUT_OF_RANGE_OBJECTS);
            Writer.Write((uint)Entitys.Count);

            foreach (ObjectEntity entity in Entitys)
            {
                Writer.WritePackedUInt64(entity.ObjectGUID.RawGUID);
            }

            
        }

        public override string BuildInfo()
        {
            return "[OutOfRange] " + string.Join(", ", Entitys.ToArray().ToList().ConvertAll<string>(e => e.Name).ToArray());
        }
    }

    public class CreateGOBlock : UpdateBlock
    {
        public GOEntity Entity { get; private set; }

        public CreateGOBlock(GOEntity entity)
        {
            Entity = entity;

            Build();
        }

        public override void BuildData()
        {
            Writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            Writer.WritePackedUInt64(Entity.ObjectGUID.RawGUID);

            Writer.Write((byte)TypeID.TYPEID_GAMEOBJECT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_TRANSPORT |
                                      ObjectUpdateFlag.UPDATEFLAG_ALL |
                                      ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            Writer.Write((byte)updateFlags);

            // Position
            Writer.Write((float)Entity.GameObject.X);
            Writer.Write((float)Entity.GameObject.Y);
            Writer.Write((float)Entity.GameObject.Z);

            Writer.Write((float)0); // R

            Writer.Write((uint)0x1); // Unkown... time?
            Writer.Write((uint)0); // Unkown... time?

            Entity.WriteUpdateFields(Writer);
        }

        public override string BuildInfo()
        {
            return "[CreateGO] " + Entity.GameObjectTemplate.Name;
        }
    }

    public class CreateUnitBlock : UpdateBlock
    {
        public UnitEntity Entity { get; private set; }

        public CreateUnitBlock(UnitEntity entity)
        {
            Entity = entity;

            Build();
        }

        public override void BuildData()
        {
            Writer.Write((byte)ObjectUpdateType.UPDATETYPE_CREATE_OBJECT);

            Writer.WritePackedUInt64(Entity.ObjectGUID.RawGUID);

            Writer.Write((byte)TypeID.TYPEID_UNIT);

            ObjectUpdateFlag updateFlags = ObjectUpdateFlag.UPDATEFLAG_ALL |
                                           ObjectUpdateFlag.UPDATEFLAG_LIVING |
                                           ObjectUpdateFlag.UPDATEFLAG_HAS_POSITION;

            Writer.Write((byte)updateFlags);
            Writer.Write((UInt32)0x00000000); //MovementFlags

            Writer.Write((UInt32)Environment.TickCount); // Time
            
            // Position
            Writer.Write((float)Entity.X);
            Writer.Write((float)Entity.Y);
            Writer.Write((float)Entity.Z);
            Writer.Write((float)Entity.R); // R

            // Movement speeds
            Writer.Write((float)0);     // ????

            Writer.Write((float)2.5f);  // MOVE_WALK
            Writer.Write((float)7);     // MOVE_RUN
            Writer.Write((float)4.5f);  // MOVE_RUN_BACK
            Writer.Write((float)4.72f); // MOVE_SWIM
            Writer.Write((float)2.5f);  // MOVE_SWIM_BACK
            Writer.Write((float)3.14f); // MOVE_TURN_RATE

            Writer.Write(0x1); // Unkown...

            Entity.Scale = 1;
            Entity.WriteUpdateFields(Writer);
        }

        public override string BuildInfo()
        {
            return "[CreateUnit] " + Entity.Name;
        }
    }
}
