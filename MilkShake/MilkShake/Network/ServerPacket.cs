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
        public int Opcode;

        public ServerPacket(int opcode) : base(new MemoryStream())
        {
            Opcode = opcode;
        }

        public ServerPacket(WorldOpcodes worldOpcode) : this((int) worldOpcode) {}

        public ServerPacket(LoginOpcodes opcode) : this((byte) opcode) {}

        public byte[] Packet
        {
            get { return (BaseStream as MemoryStream).ToArray(); }
        }
    }
}
