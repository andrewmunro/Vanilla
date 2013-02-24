using System;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Communication.Outgoing.World.Chat;
using Milkshake.Game.Constants.Game;
using Milkshake.Net;
using Milkshake.Network;
using Milkshake.Tools.Database;

namespace Milkshake.Game.World.Chat
{
    public class ChatManager
    {
        public static void OnChatMessage(WorldSession session, PCMessageChat packet)
        {
            if (packet.Type == ChatMessageType.CHAT_MSG_WHISPER)
            {
                Console.WriteLine("[Chat] Whisper:" + " To:" + packet.To + " From:" + session.Account.Username + " Message:" + packet.Message);
                WorldSession remoteSession = GetSessionByCharacterName(packet.To);
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
            session.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_COMMON, (uint)remoteSession.Character.GUID, (UInt32) 20, message));
            remoteSession.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_COMMON, (uint)remoteSession.Character.GUID, (uint)session.Character.GUID, message));
        }

        public static void SendSytemMessage(WorldSession session, string message)
        {
            session.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_SYSTEM, ChatMessageLanguage.LANG_COMMON, 0, 0, message));
        }

        public static WorldSession GetSessionByUsername(string username)
        {
             return WorldServer.Sessions.Find(user => user.Account.Username.ToLower() == username.ToLower());
        }

        public static WorldSession GetSessionByCharacterName(string characterName)
        {
            return WorldServer.Sessions.Find(character => character.Character.Name.ToLower() == characterName.ToLower());
        }

        public static void OnNameQuery(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);
            if(target != null) session.sendPacket(new PSNameQuery(target));
        }
    }
}
