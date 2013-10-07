using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace Vanilla.World.Tools.Database.Helpers
{
    public class DBChannels
    {
        public static TableQuery<Channel> ChannelQuery
        {
            get { return DB.Character.Table<Channel>(); }
        }

        public static TableQuery<ChannelCharacter> ChannelCharacterQuery
        {
            get { return DB.Character.Table<ChannelCharacter>(); }
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

        public static List<Character> GetCharacters(String channelName)
        {
            int channelID = GetChannel(channelName).ID;
            return DB.Character.Query<Character>("select * from Character left join ChannelCharacter where ChannelCharacter.GUID = ?", channelID);
        }

        public static ChannelCharacter GetChannelCharacter(int guid, string channelName)
        {
            return ChannelCharacters.Find(c => c.GUID == guid && c.ChannelID == GetChannel(channelName).ID);
        }

        public static List<ChannelCharacter> GetChannelCharacters(Character character)
        {
            return ChannelCharacterQuery.ToList().FindAll(c => c.GUID == character.GUID);
        }

        public static void CreateChannel(int guid, String channelName)
        {
            DB.Character.Insert(new Channel() { Name = channelName, DateCreated = DateTime.Now, OwnerGUID = guid });
            JoinChannel(guid, channelName);
        }

        public static void JoinChannel(int guid, String channelName)
        {
            if (GetChannel(channelName) != null)
            {
                if (GetChannelCharacter(guid, channelName) == null) DB.Character.Insert(new ChannelCharacter() { GUID = guid, ChannelID = GetChannel(channelName).ID });
            }
            else CreateChannel(guid, channelName);
        }

        public static void LeaveChannel(int guid, String channelName)
        {
            DB.Character.Delete(GetChannelCharacter(guid, channelName));
        }
    }
}
