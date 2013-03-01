using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.Database.Tables;
using SQLite;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBChannels
    {
        public static TableQuery<Channel> ChannelQuery
        {
            get { return DB.SQLite.Table<Channel>(); }
        }

        public static TableQuery<ChannelCharacter> ChannelCharacterQuery
        {
            get { return DB.SQLite.Table<ChannelCharacter>(); }
        }

        public static List<Character> GetCharacters(String channelName)
        {
            int channelID = GetChannel(channelName).ID;
            return DB.SQLite.Query<Character>("select * from Character left join ChannelCharacter where ChannelCharacter.GUID = ?", channelID);
        }

        public static List<Channel> Channels
        {
            get { return ChannelQuery.ToList<Channel>(); }
        }

        public static List<ChannelCharacter> ChannelCharacters
        {
            get { return ChannelCharacterQuery.ToList<ChannelCharacter>(); }
        }

        public static Channel GetChannel(String channel)
        {
            return Channels.Find(c => c.Name == channel);
        }

        public static Channel GetChannel(int channelID)
        {
            return Channels.Find(c => c.ID == channelID);
        }

        public static ChannelCharacter GetChannelCharacter(int guid, string channelName)
        {
            return ChannelCharacters.Find(c => c.GUID == guid && c.ChannelID == GetChannel(channelName).ID);
        }

        public static void CreateChannel(int guid, String channelName)
        {
            DB.SQLite.Insert(new Channel() { Name = channelName, DateCreated = DateTime.Now, OwnerGUID = guid });
            JoinChannel(guid, channelName);
        }

        public static void JoinChannel(int guid, String channelName)
        {
            if (GetChannel(channelName) != null)
            {
                if (GetChannelCharacter(guid, channelName) == null) DB.SQLite.Insert(new ChannelCharacter() { GUID = guid, ChannelID = GetChannel(channelName).ID });
            }
            else CreateChannel(guid, channelName);
        }

        public static void LeaveChannel(int guid, String channelName)
        {
            DB.SQLite.Delete(GetChannelCharacter(guid, channelName));
        }
    }
}
