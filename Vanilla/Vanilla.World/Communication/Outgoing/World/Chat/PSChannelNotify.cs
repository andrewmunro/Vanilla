using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Chat
{
    #region

    using System;
    using System.Text;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Constants.Game.Chat.Channel;

    #endregion

    internal class PSChannelNotify : WorldPacket
    {
        #region Constructors and Destructors

        public PSChannelNotify(ChatChannelNotify type, ulong GUID, string channelName)
            : base(WorldOpcodes.SMSG_CHANNEL_NOTIFY)
        {
            Write((byte)type);
            Write(Encoding.UTF8.GetBytes(channelName + '\0'));
            Write(GUID);

            // Write((byte)0x03); // Flags
            // Write((uint)1); // ID
            // Write((uint)0); // ?
        }

        #endregion
    }
}