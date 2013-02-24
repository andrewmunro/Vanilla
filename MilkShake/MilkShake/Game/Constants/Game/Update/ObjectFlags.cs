using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Update
{
    [Flags]
    public enum ObjectFlags : byte
    {
        UPDATEFLAG_NONE = 0x0000,
        UPDATEFLAG_SELF = 0x0001,
        UPDATEFLAG_TRANSPORT = 0x0002,
        UPDATEFLAG_FULLGUID = 0x0004,
        UPDATEFLAG_HIGHGUID = 0x0008,
        UPDATEFLAG_ALL = 0x0010,
        UPDATEFLAG_LIVING = 0x0020,
        UPDATEFLAG_HAS_POSITION = 0x0040
    }
}
