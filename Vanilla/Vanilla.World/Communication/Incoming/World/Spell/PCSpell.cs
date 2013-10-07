using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Spell
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
