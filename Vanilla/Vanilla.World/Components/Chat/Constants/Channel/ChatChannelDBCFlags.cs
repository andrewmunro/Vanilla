namespace Vanilla.World.Components.Chat.Constants.Channel
{
    using System;

    [Flags]
    public enum ChatChannelDBCFlags
    {
        CHANNEL_DBC_FLAG_NONE = 0x00000,
        CHANNEL_DBC_FLAG_INITIAL = 0x00001,          // General, Trade, LocalDefense, LFG
        CHANNEL_DBC_FLAG_ZONE_DEP = 0x00002,          // General, Trade, LocalDefense, GuildRecruitment
        CHANNEL_DBC_FLAG_GLOBAL = 0x00004,          // WorldDefense
        CHANNEL_DBC_FLAG_TRADE = 0x00008,          // Trade
        CHANNEL_DBC_FLAG_CITY_ONLY = 0x00010,          // Trade, GuildRecruitment
        CHANNEL_DBC_FLAG_CITY_ONLY2 = 0x00020,          // Trade, GuildRecruitment
        CHANNEL_DBC_FLAG_DEFENSE = 0x10000,          // LocalDefense, WorldDefense
        CHANNEL_DBC_FLAG_GUILD_REQ = 0x20000,          // GuildRecruitment
        CHANNEL_DBC_FLAG_LFG = 0x40000           // LookingForGroup
    }
}
