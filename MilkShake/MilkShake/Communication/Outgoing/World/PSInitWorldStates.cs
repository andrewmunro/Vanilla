using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Milkshake.Communication.Outgoing.World
{
    public class PSInitWorldStates : BinaryWriter
    {
        public PSInitWorldStates() : base(new MemoryStream())
        {

        }

        public byte[] Packet { get { return (BaseStream as MemoryStream).ToArray(); } }
    }
}
