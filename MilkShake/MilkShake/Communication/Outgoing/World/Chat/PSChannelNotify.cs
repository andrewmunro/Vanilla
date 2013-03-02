using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Constants.Game.Chat.Channel;
using Milkshake.Network;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Communication.Outgoing.World.Chat
{
    class PSChannelNotify : ServerPacket
    {
        public PSChannelNotify(ChatChannelNotify type, ulong GUID, String channelName) : base(Opcodes.SMSG_CHANNEL_NOTIFY)
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
