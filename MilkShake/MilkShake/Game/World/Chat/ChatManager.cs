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
            if (packet.Type == ChatMessageType.CHAT_MSG_WHISPER)
            {
                Console.WriteLine("[Chat] Whisper:" + " To:" + packet.To + " From:" + session.Account.Username + " Message:" + packet.Message);
                WorldSession remoteSession = GetSessionByUsername(packet.To);
                if (remoteSession != null) SendWhisper(session, remoteSession, packet.Message);
            }
            else
            {
                Console.WriteLine("[Chat] Type:" + packet.Type.ToString() + " Language:" + packet.Language.ToString() + " Message:" + packet.Message);
                SendSytemMessage(session, "[Chat] [" + packet.Type.ToString() + "] " + packet.Message);
            }

        }

        private static void SendWhisper(WorldSession session, WorldSession remoteSession, string message)
        {
            //session.sendPacket(Opcodes.SMSG_MESSAGECHAT, new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_COMMON, remoteSession.Character.GUID, session.Character.GUID, message).Packet;
           // remoteSession.sendPacket(Opcodes.SMSG_MESSAGECHAT, new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_COMMON, remoteSession.Character.GUID, session.Character.GUID, message).Packet;
        }

        public static void SendSytemMessage(WorldSession session, string message)
        {
            session.sendPacket(Opcodes.SMSG_MESSAGECHAT, new PSMessageChat(ChatMessageType.CHAT_MSG_SYSTEM, ChatMessageLanguage.LANG_COMMON, 0, 0, message).Packet);
        }

        public static WorldSession GetSessionByUsername(string username)
        {
             return WorldServer.Sessions.Find(user => user.Account.Username.ToLower() == username.ToLower());
        }
    }
}
