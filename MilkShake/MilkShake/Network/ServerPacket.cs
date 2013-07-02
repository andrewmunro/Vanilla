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
        public byte Opcode;

        public ServerPacket(byte opcode) : base(new MemoryStream())
        {
            Opcode = opcode;
        }

        public ServerPacket(Opcodes opcode) : this((byte) opcode) {}

        public ServerPacket(AuthOpcodes opcode) : this((byte) opcode) {}

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
