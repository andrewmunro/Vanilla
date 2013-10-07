using System;

namespace Vanilla.World.Game.Constants.Game.Chat.Channel
{
    [Flags]
    public enum ChatChannelMemberFlags
    {
        MEMBER_FLAG_NONE = 0x00,
        MEMBER_FLAG_OWNER = 0x01,
        MEMBER_FLAG_MODERATOR = 0x02,
        MEMBER_FLAG_VOICED = 0x04,
        MEMBER_FLAG_MUTED = 0x08,
        MEMBER_FLAG_CUSTOM = 0x10,
        MEMBER_FLAG_MIC_MUTED = 0x20,
        // 0x40
        // 0x80
    }
}
