using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Movement
{
    #region

    using System;
    using Database.Character.Models;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game.Constants.Game.Update;

    #endregion

    public sealed class PSMoveHeartbeat : WorldPacket
    {
        #region Constructors and Destructors

        public PSMoveHeartbeat(Character character)
            : base(WorldOpcodes.MSG_MOVE_HEARTBEAT)
        {
            byte[] packedGUID = PSUpdateObject.GenerateGuidBytes((ulong)character.GUID);
            PSUpdateObject.WriteBytes(this, packedGUID);
            Write((uint)MovementFlags.MOVEFLAG_NONE);
            Write((uint)1); // Time
            Write(character.PositionX);
            Write(character.PositionY);
            Write(character.PositionZ);
            Write(character.Orientation);
            Write((uint)0); // ?
        }

        #endregion
    }
}