using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Logout
{
    class SCLogoutResponse : BinaryWriter
    {
        public SCLogoutResponse() : base(new MemoryStream())
        {
            Write((UInt32) 0);
            Write((byte) 0);
        }
    }
}
