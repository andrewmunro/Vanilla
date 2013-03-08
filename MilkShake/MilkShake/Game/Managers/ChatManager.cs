﻿using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Outgoing.World.Chat;
using Milkshake.Game.Constants.Game;
using Milkshake.Net;
using Milkshake.Game.Handlers;
using Milkshake.Communication;
using System.Collections.Generic;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.DBC;
using System.Linq;
using System;

namespace Milkshake.Game.Managers
{
    public delegate void ProcessChatCallback(WorldSession Session, PCMessageChat message);

    public class ChatManager
    {
        public static Dictionary<ChatMessageType, ProcessChatCallback> ChatHandlers;

        public static void Boot()
        {
            DataRouter.AddHandler<PCMessageChat>(Opcodes.CMSG_MESSAGECHAT, OnMessageChatPacket);

            ChatHandlers = new Dictionary<ChatMessageType,ProcessChatCallback>();
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_SAY, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_YELL, OnSayYell);
            ChatHandlers.Add(ChatMessageType.CHAT_MSG_WHISPER, OnWhisper);
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
            //PSUpdateObject.CreateCharacterUpdate
            string[] splitMessage = packet.Message.Split(' ');

        

            if (splitMessage.Length == 2)
            {
                if (splitMessage[0].ToLower() == "lookup")
                {
                    string value = splitMessage[1];
                    List<SpellEntry> matchingSpells = DBC.Spells.Where(s => s.Name.Contains(value)).ToList();

                    matchingSpells.ForEach(s => session.sendMessage("[" + s.ID + "] " + s.Name));
                }

                if (splitMessage[0].ToLower() == "spell")
                {
                    SpellManager.OnLearnSpell(session, int.Parse(splitMessage[1]));
                }
            }

            if (splitMessage[0].ToLower() == "pow")
            {
                
            }

            WorldServer.TransmitToAll(new PSMessageChat(packet.Type, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message));
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