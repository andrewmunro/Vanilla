﻿using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.Players
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public sealed class PSTransferPending : WorldPacket
    {
        #region Constructors and Destructors

        public PSTransferPending(int mapID)
            : base(WorldOpcodes.SMSG_TRANSFER_PENDING)
        {
            Write(mapID);
        }

        #endregion
    }
}