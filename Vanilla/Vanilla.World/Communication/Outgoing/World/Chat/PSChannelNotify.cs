using System;
using System.Text;
using Vanilla.World.Game.Constants.Game.Chat.Channel;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Chat
{
    using Vanilla.Core.Opcodes;

    class PSChannelNotify : ServerPacket
    {
        public PSChannelNotify(ChatChannelNotify type, ulong GUID, String channelName) : base(WorldOpcodes.SMSG_CHANNEL_NOTIFY)
        {
            Write((byte)type);
            Write(Encoding.UTF8.GetBytes(channelName + '\0'));
            Write((ulong)GUID);

            //Write((byte)0x03); // Flags
            //Write((uint)1); // ID
            //Write((uint)0); // ?
        }
    }
}
