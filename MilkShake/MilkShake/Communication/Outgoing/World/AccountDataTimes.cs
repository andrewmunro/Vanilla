using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Milkshake.Communication.Outgoing.World
{
    public class AccountDataTimes : BinaryWriter
    {
        public AccountDataTimes() : base(new MemoryStream())
        {
            // Odd?
            for(int i = 0; i < 32; ++i) Write((UInt32)0);
        }

        public byte[] Packet { get { return (BaseStream as MemoryStream).ToArray(); } }
    }
}
