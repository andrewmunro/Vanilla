namespace Vanilla.World.Components.Movement.Packets.Outgoing
{
    using System;
    using System.IO;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Movement.Packets.Incoming;
    using Vanilla.World.Network;

    public class PSMovement : WorldPacket
    {
        public PSMovement(WorldOpcodes worldOpcode, WorldSession session, PCMoveInfo moveinfo)
            : base(worldOpcode)
        {
            var correctedMoveTime = (uint)Environment.TickCount;

            byte[] packedGUID = session.Player.ObjectGUID.GetGuidBytes();
            this.WriteBytes(packedGUID);
            this.WriteBytes((moveinfo.BaseStream as MemoryStream).ToArray());

            // We then overwrite the original moveTime (sent from the client) with ours
            (this.BaseStream as MemoryStream).Position = 4 + packedGUID.Length;
            this.WriteBytes(BitConverter.GetBytes(correctedMoveTime));
        }
    }
}