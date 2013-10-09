namespace Vanilla.World.Communication.Outgoing.World.Chat
{
    #region

    using System.Text;

    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Constants.Game.Chat;

    #endregion

    public class PSMessageChat : ServerPacket
    {
        #region Fields

        private string channel;

        #endregion

        #region Constructors and Destructors

        public PSMessageChat(
            ChatMessageType type, 
            ChatMessageLanguage language, 
            ulong GUID, 
            string message, 
            string channelName = null)
            : base(WorldOpcodes.SMSG_MESSAGECHAT)
        {
            Write((byte)type);

            Write((uint)language);

            if (type == ChatMessageType.CHAT_MSG_CHANNEL)
            {
                Write(Encoding.UTF8.GetBytes(channelName + '\0'));
                Write((uint)0);
            }

            Write(GUID);

            if (type == ChatMessageType.CHAT_MSG_SAY || type == ChatMessageType.CHAT_MSG_YELL
                || type == ChatMessageType.CHAT_MSG_PARTY)
            {
                Write(GUID);
            }

            Write((uint)message.Length + 1);
            Write(Encoding.UTF8.GetBytes(message + '\0'));
            Write((byte)0);
        }

        #endregion
    }
}