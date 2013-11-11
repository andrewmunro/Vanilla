namespace Vanilla.World.Components.Chat.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Chat.Constants.Channel;

    internal class PSChannelNotify : WorldPacket
    {
        public PSChannelNotify(ChatChannelNotify type, ulong GUID, string channelName)
            : base(WorldOpcodes.SMSG_CHANNEL_NOTIFY)
        {
            this.Write((byte)type);
            this.Write(Encoding.UTF8.GetBytes(channelName + '\0'));
            this.Write(GUID);

            // Write((byte)0x03); // Flags
            // Write((uint)1); // ID
            // Write((uint)0); // ?
        }
    }
}