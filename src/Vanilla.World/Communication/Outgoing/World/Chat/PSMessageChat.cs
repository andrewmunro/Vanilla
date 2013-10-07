using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Game.Constants.Game;
using Milkshake.Network;
using Milkshake.Game.Entitys;
using Milkshake.Communication.Outgoing.World.Update;

namespace Milkshake.Communication.Outgoing.World.Chat
{
	public class PSMessageChat : ServerPacket
	{
		private string channel;
		
		public PSMessageChat(ChatMessageType type, ChatMessageLanguage language, ulong GUID, string message, string channelName = null)  : base(WorldOpcodes.SMSG_MESSAGECHAT)
		{
			Write((byte)type);

			Write((uint)language);            

			if (type == ChatMessageType.CHAT_MSG_CHANNEL)
			{
				Write(Encoding.UTF8.GetBytes(channelName + '\0'));
				Write((uint)0); 
			}

			Write((ulong)GUID);

			if (type == ChatMessageType.CHAT_MSG_SAY || type == ChatMessageType.CHAT_MSG_YELL || type == ChatMessageType.CHAT_MSG_PARTY)
			{
				Write((ulong)GUID);
			}

			Write((uint)message.Length + 1);
			Write(Encoding.UTF8.GetBytes(message + '\0'));
			Write((byte)0);
	   
		} 
	}
}
