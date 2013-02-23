using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Milkshake.Communication.Outgoing.World
{
    internal class PSPlaySound : BinaryWriter
    {
        public PSPlaySound(uint soundID) : base(new MemoryStream())
        {
            Write(soundID);
        }

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
