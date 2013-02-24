using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Milkshake.Communication;

namespace Milkshake.Network
{
    public class ServerPacket : BinaryWriter
    {
        public Opcodes Opcode;

        public ServerPacket(Opcodes opcode)
        {
            Opcode = opcode;
        }

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
