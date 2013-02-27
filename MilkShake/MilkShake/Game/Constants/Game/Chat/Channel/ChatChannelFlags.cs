using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.Chat.Channel
{
    [Flags]
    public enum ChatChannelFlags
    {
        CHANNEL_FLAG_NONE = 0x00,
        CHANNEL_FLAG_CUSTOM = 0x01,
        // 0x02
        CHANNEL_FLAG_TRADE = 0x04,
        CHANNEL_FLAG_NOT_LFG = 0x08,
        CHANNEL_FLAG_GENERAL = 0x10,
        CHANNEL_FLAG_CITY = 0x20,
        CHANNEL_FLAG_LFG = 0x40,
        CHANNEL_FLAG_VOICE = 0x80
    }
}
