using System;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Outgoing.World.Chat;
using Milkshake.Game.Constants.Game;
using Milkshake.Net;

namespace Milkshake.Game.World.Chat
{
    public class ChatManager
    {
        public static void OnChatMessage(WorldSession session, PCMessageChat packet)
        {
            Console.WriteLine("[Chat] Type:" + packet.Type.ToString() + " Language:" + packet.Language.ToString() + " Message:" + packet.Message);

            SendSytemMessage(session, "[Chat] [" + packet.Type.ToString() + "] " + packet.Message);
        }

        public static void SendSytemMessage(WorldSession session, string message)
        {
            session.sendPacket(Opcodes.SMSG_MESSAGECHAT, new PSMessageChat(ChatMessageType.CHAT_MSG_SYSTEM, ChatMessageLanguage.LANG_COMMON, 0, 0, message).Packet);
        }
    }
}
