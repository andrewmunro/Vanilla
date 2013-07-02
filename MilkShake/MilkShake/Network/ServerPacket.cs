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

        public ServerPacket(WorldOpcodes worldOpcode) : this((byte) worldOpcode) {}

        public ServerPacket(LoginOpcodes opcode) : this((byte) opcode) {}

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
