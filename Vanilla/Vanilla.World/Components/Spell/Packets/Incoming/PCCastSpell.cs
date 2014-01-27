namespace Vanilla.World.Components.Spell.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    internal sealed class PCCastSpell : PacketReader
    {
        public PCCastSpell(byte[] data)
            : base(data)
        {
            this.spellID = this.ReadUInt32();
            this.target = this.ReadCString();
        }

        public uint spellID { get; private set; }

        public string target { get; private set; }
    }
}