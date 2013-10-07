using System;
using System.Collections.Generic;
using Vanilla.World.Communication.Chat;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.Chat;
using Vanilla.World.Game.Constants.Game.Chat;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Tools.Chat;

namespace Vanilla.World.Game.Managers
{
    public delegate void ProcessChatCallback(WorldSession Session, PCMessageChat message);

    public delegate void ChatCommandDelegate(WorldSession Session, String[] args);

    public class ChatManager
    {
        public static Dictionary<ChatMessageType, ProcessChatCallback> ChatHandlers;

        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCMessageChat>(WorldOpcodes.CMSG_MESSAGECHAT, OnMessageChatPacket);

            ChatHandlers = new Dictionary<ChatMessageType,ProcessChatCallback>();
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_SAY, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_YELL, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_EMOTE, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_WHISPER, OnWhisper);
        }

        public static void AddChatCommand(String commandName, String commandDescription, ChatCommandDelegate method)
        {
            ChatCommandNode node = new ChatCommandNode(commandName, commandDescription);
            node.Method = method.Method;
            node.CommandAttributes = new List<ChatCommandAttribute>();
            ChatCommandParser.AddNode(node);
        }

        public static void RemoveChatCommand(String commandName)
        {
            ChatCommandParser.RemoveNode(commandName);
        }

        public static void OnMessageChatPacket(WorldSession session, PCMessageChat packet)
        {
            if (ChatHandlers.ContainsKey(packet.Type))
            {
                ChatHandlers[packet.Type](session, packet);
            }
        }

        public static void OnSayYell(WorldSession session, PCMessageChat packet)
        {
            if (packet.Message[0].ToString() == INI.GetValue(ConfigSections.WORLD, ConfigValues.COMMAND_KEY)) ChatCommandParser.ExecuteCommand(session, packet.Message);
            else WorldServer.TransmitToAll(new PSMessageChat(packet.Type, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message));
        }

        public static void OnWhisper(WorldSession session, PCMessageChat packet)
        {
            WorldSession remoteSession = WorldServer.GetSessionByPlayerName(packet.To);

            if (remoteSession != null)
            {
                session.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER_INFORM, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)remoteSession.Character.GUID, packet.Message)); 
                remoteSession.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message)); 
            }
            else
            {
                session.sendMessage("Player not found.");
            }
        }        

        public static void SendSytemMessage(WorldSession session, string message)
        {
            session.sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_SYSTEM, ChatMessageLanguage.LANG_COMMON, 0, message));
        }

        public static WorldSession GetSessionByCharacterName(string characterName)
        {
            return WorldServer.Sessions.Find(character => character.Character.Name.ToLower() == characterName.ToLower());
        }
    }
}
