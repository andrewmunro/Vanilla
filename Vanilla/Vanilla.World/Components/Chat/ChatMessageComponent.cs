namespace Vanilla.World.Components.Chat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Config;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Chat.Constants;
    using Vanilla.World.Components.Chat.Constants.Channel;
    using Vanilla.World.Components.Chat.Packets.Incoming;
    using Vanilla.World.Components.Chat.Packets.Outgoing;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.Chat;

    public delegate void ProcessChatCallback(WorldSession Session, PCMessageChat message);

    public delegate void ChatCommandDelegate(WorldSession Session, String[] args);

    public class ChatMessageComponent : WorldServerComponent
    {
        public List<ChatChannel> ChatChannels;

        public Dictionary<ChatMessageType, ProcessChatCallback> ChatHandlers;

        public ChatMessageComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            ChatChannels = new List<ChatChannel>();

            Router.AddHandler<PCMessageChat>(WorldOpcodes.CMSG_MESSAGECHAT, OnMessageChatPacket);
            Router.AddHandler<PCJoinChannel>(WorldOpcodes.CMSG_JOIN_CHANNEL, OnJoinChannel);
            Router.AddHandler<PCChannel>(WorldOpcodes.CMSG_LEAVE_CHANNEL, OnLeaveChannel);
            Router.AddHandler<PCChannel>(WorldOpcodes.CMSG_CHANNEL_LIST, OnListChannel);

            ChatHandlers = new Dictionary<ChatMessageType,ProcessChatCallback>();
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_SAY, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_YELL, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_EMOTE, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_WHISPER, OnWhisper);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_CHANNEL, OnChannelMessage);
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
            if (packet.Message[0].ToString() == Config.GetValue(ConfigSections.WORLD, ConfigValues.COMMAND_KEY)) Core.ChatCommands.ExecuteCommand(session, packet.Message);
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
                session.SendMessage("Player not found.");
            }
        }

        private void OnListChannel(WorldSession session, PCChannel packet)
        {
            session.SendMessage("Users in channel " + packet.ChannelName + ":");
            var channel = ChatChannels.SingleOrDefault(ch => ch.Name == packet.ChannelName);
            channel.Sessions.ForEach(s => session.SendMessage(s.Player.Name));
        }

        private void OnLeaveChannel(WorldSession session, PCChannel packet)
        {
            var channel = ChatChannels.SingleOrDefault(c => c.Name == packet.ChannelName);
            channel.Sessions.Remove(session);

            if (channel.Sessions.Count == 0) ChatChannels.Remove(channel);

            session.SendPacket(new PSChannelNotify(ChatChannelNotify.CHAT_YOU_LEFT_NOTICE, session.Player.ObjectGUID.RawGUID, packet.ChannelName));
        }

        private void OnJoinChannel(WorldSession session, PCJoinChannel packet)
        {
            var channel = ChatChannels.SingleOrDefault(c => c.Name == packet.ChannelName);
            if (channel == null)
            {
                channel = new ChatChannel(packet.ChannelName, packet.Password);
                ChatChannels.Add(channel);
            }
            channel.Sessions.Add(session);

            session.SendPacket(new PSChannelNotify(ChatChannelNotify.CHAT_YOU_JOINED_NOTICE, session.Player.ObjectGUID.RawGUID, packet.ChannelName));
        }

        private void OnChannelMessage(WorldSession session, PCMessageChat packet)
        {
            var channel = ChatChannels.SingleOrDefault(c => c.Name == packet.ChannelName);
            channel.Sessions.ForEach(s => s.SendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_CHANNEL, ChatMessageLanguage.LANG_UNIVERSAL, session.Player.ObjectGUID.RawGUID, packet.Message, packet.ChannelName)));
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
