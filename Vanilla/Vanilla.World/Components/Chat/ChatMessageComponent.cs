namespace Vanilla.World.Components.Chat
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Core.Config;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Chat.Constants;
    using Vanilla.World.Components.Chat.Packets.Incoming;
    using Vanilla.World.Components.Chat.Packets.Outgoing;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.Chat;

    public delegate void ProcessChatCallback(WorldSession Session, PCMessageChat message);

    public delegate void ChatCommandDelegate(WorldSession Session, String[] args);

    public class ChatMessageComponent : WorldServerComponent
    {
        public static Dictionary<ChatMessageType, ProcessChatCallback> ChatHandlers;

        public ChatMessageComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            this.Router.AddHandler<PCMessageChat>(WorldOpcodes.CMSG_MESSAGECHAT, OnMessageChatPacket);

            ChatHandlers = new Dictionary<ChatMessageType,ProcessChatCallback>();
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_SAY, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_YELL, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_EMOTE, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_WHISPER, OnWhisper);
        }

        public void AddChatCommand(String commandName, String commandDescription, ChatCommandDelegate method)
        {
            ChatCommandNode node = new ChatCommandNode(commandName, commandDescription);
            node.Method = method.Method;
            node.CommandAttributes = new List<ChatCommandAttribute>();
            ChatCommandParser.AddNode(node);
        }

        public void RemoveChatCommand(String commandName)
        {
            ChatCommandParser.RemoveNode(commandName);
        }

        public void OnMessageChatPacket(WorldSession session, PCMessageChat packet)
        {
            if (ChatHandlers.ContainsKey(packet.Type))
            {
                ChatHandlers[packet.Type](session, packet);
            }
        }

        public void OnSayYell(WorldSession session, PCMessageChat packet)
        {
            if (packet.Message[0].ToString() == Config.GetValue(ConfigSections.WORLD, ConfigValues.COMMAND_KEY)) ChatCommandParser.ExecuteCommand(session, packet.Message);
            else Server.TransmitToAll(new PSMessageChat(packet.Type, ChatMessageLanguage.LANG_UNIVERSAL, session.Player.ObjectGUID.RawGUID, packet.Message));
        }

        public void OnWhisper(WorldSession session, PCMessageChat packet)
        {
            WorldSession remoteSession = Server.GetSessionByPlayerName(packet.To);

            if (remoteSession != null)
            {
                session.SendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER_INFORM, ChatMessageLanguage.LANG_UNIVERSAL, remoteSession.Player.ObjectGUID.RawGUID, packet.Message)); 
                remoteSession.SendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_WHISPER, ChatMessageLanguage.LANG_UNIVERSAL, session.Player.ObjectGUID.RawGUID, packet.Message)); 
            }
            else
            {
                session.sendMessage("Player not found.");
            }
        }        

        public void SendSytemMessage(WorldSession session, string message)
        {
            session.SendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_SYSTEM, ChatMessageLanguage.LANG_COMMON, 0, message));
        }

        public WorldSession GetSessionByCharacterName(string characterName)
        {
            return Server.Sessions.Find(character => String.Equals(character.Player.Character.Name, characterName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
