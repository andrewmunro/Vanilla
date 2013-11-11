namespace Vanilla.World.Components.Chat.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Chat.Constants;

    public class PSMessageChat : WorldPacket
    {
        private string channel;

        public PSMessageChat(ChatMessageType type, ChatMessageLanguage language, ulong GUID, string message, string channelName = null) : base(WorldOpcodes.SMSG_MESSAGECHAT)
        {
            this.Write((byte)type);

            this.Write((uint)language);

            if (type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                this.Write(Encoding.UTF8.GetBytes(channelName + '\0'));
                this.Write((uint)0);
            }

            this.Write(GUID);

            if (type == ChatMessageType.CHAT_MSG_SAY || type == ChatMessageType.CHAT_MSG_YELL
                || type == ChatMessageType.CHAT_MSG_PARTY)
            {
                this.Write(GUID);
            }

            this.Write((uint)message.Length + 1);
            this.Write(Encoding.UTF8.GetBytes(message + '\0'));
            this.Write((byte)0);
        }
    }
}