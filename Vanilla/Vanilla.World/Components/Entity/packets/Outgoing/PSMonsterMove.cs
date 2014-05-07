using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Vanilla.Core.Extensions;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;
using Vanilla.Core.Tools;
using Vanilla.World.Components.Entity.Constants;
using Vanilla.World.Game.Entity;
using Vanilla.World.Game.Entity.Object.Creature;

namespace Vanilla.World.Components.Entity.packets.Outgoing
{
    internal sealed class PSMonsterMove : WorldPacket
    {
        public PSMonsterMove(CreatureEntity target, List<Vector3> path)
            : base(WorldOpcodes.SMSG_MONSTER_MOVE)
        {
            this.WritePackedUInt64(target.ObjectGUID.RawGUID);
            this.Write(target.Location.X);
            this.Write(target.Location.Y);
            this.Write(target.Location.Z);
            this.Write((UInt32)Environment.TickCount);
            this.Write((byte)0); // SPLINETYPE_NORMAL
            this.Write(0); // sPLINE FLAG
            var time = this.GetDistanceForPath(target.Location.Position, path) / UnitSpeed.UNIT_NORMAL_RUN_SPEED * 1000;
            this.Write((int)time); // TIME
            this.Write(path.Count);//count
            for (int i = 0; i < path.Count; i++)
            {
                this.Write(path[i].X);
                this.Write(path[i].Y);
                this.Write(path[i].Z);
            }
        }

        //TODO Test and fix this function, time may be a per waypoint value.
        private float GetDistanceForPath(Vector3 startingLocation, List<Vector3> path)
        {
            var dist = 0f;

            dist += Vector3.Distance(startingLocation, path[0]);

            for (int i = 0; i < path.Count - 1; i++)
            {
                dist += Vector3.Distance(path[i], path[i + 1]);
            }
            return dist;
        }
    }
}