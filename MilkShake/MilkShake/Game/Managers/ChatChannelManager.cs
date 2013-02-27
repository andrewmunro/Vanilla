using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Incoming.World.Player;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Handlers;
using Milkshake.Net;

namespace Milkshake.Game.Managers
{
    class ChatChannelManager
    {
        public static void Boot()
        {
            ChatManager.ChatHandlers.Add(ChatMessageType.CHAT_MSG_WHISPER, OnChannelMessage);
        }

        private static void OnChannelMessage(WorldSession session, PCMessageChat packet)
        {
            throw new NotImplementedException();
        }
    }
}
