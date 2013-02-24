using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Milkshake.Communication.Outgoing.World.Chat
{
    internal class PSMessageChat : BinaryWriter
    {
        public PSMessageChat( soundID) : base(new MemoryStream())
        {
            Write(soundID);
        }

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
