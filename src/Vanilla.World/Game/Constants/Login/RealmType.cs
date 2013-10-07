using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Login
{
    public enum RealmType : byte
    {
        Normal = 0x00,
        PVP = 0x01,
        RP = 0x06,
        RPPVP = 0x08,
    }
}
