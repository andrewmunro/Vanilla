using System;
using System.Collections.Generic;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Incoming.World.Chat.Channel;
using Milkshake.Communication.Outgoing.World.Chat;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Constants.Game.Chat.Channel;
using Milkshake.Game.Handlers;
using Milkshake.Net;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using Milkshake.Network;
using Milkshake.Tools;

namespace Milkshake.Game.Managers
{
    public class ChatChannelManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_JOIN_CHANNEL, OnJoinChannel);
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_LEAVE_CHANNEL, OnLeaveChannel);
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_CHANNEL_LIST, OnListChannel);
            ChatManager.ChatHandlers.Add(ChatMessageType.CHAT_MSG_CHANNEL, OnChannelMessage);
        }

        private static void OnListChannel(WorldSession session, PCChannel packet)
        {
            throw new NotImplementedException();
        }

        private static void OnLeaveChannel(WorldSession session, PCChannel packet)
        {
            DBChannels.LeaveChannel(session.Character.GUID, packet.ChannelName);
        }

        private static void OnJoinChannel(WorldSession session, PCChannel packet)
        {
            DBChannels.JoinChannel(session.Character.GUID, packet.ChannelName);
            session.sendPacket(new PSChannelNotify(ChatChannelNotify.CHAT_YOU_JOINED_NOTICE, (ulong)session.Character.GUID, packet.ChannelName));
        }

        //When channel gets a message!
        private static void OnChannelMessage(WorldSession session, PCMessageChat packet)
        {
            List<Character> inChannel = DBChannels.GetCharacters(packet.ChannelName);
            //inChannel.ForEach(c => WorldServer.Sessions.Find(s => s.Character == c).sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_CHANNEL, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message, packet.ChannelName)));;

            ServerPacket outPacket = new PSMessageChat(ChatMessageType.CHAT_MSG_CHANNEL, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message, packet.ChannelName);

            Console.WriteLine(Helper.ByteArrayToHex(outPacket.Packet));

            WorldServer.TransmitToAll(outPacket);
        }
    }
}
