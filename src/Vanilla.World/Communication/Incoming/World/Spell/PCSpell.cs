using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Incoming.World.Spell
{
    class PCCastSpell : PacketReader
    {
        public uint spellID { get; private set; }

        public string target { get; private set; }

        public PCCastSpell(byte[] data) : base(data)
        {
            spellID = ReadUInt32();
            target = ReadCString();
        }
    }

    class PCCancelSpell : PacketReader
    {
        public uint spellID { get; private set; }

        public PCCancelSpell(byte[] data) : base(data)
        {
            spellID = ReadUInt32();
        }
    }
}
