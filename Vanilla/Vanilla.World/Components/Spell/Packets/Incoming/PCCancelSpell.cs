namespace Vanilla.World.Components.Spell.Packets.Incoming
{
    using Vanilla.Core.Network.IO;

    internal sealed class PCCancelSpell : PacketReader
    {
        public PCCancelSpell(byte[] data)
            : base(data)
        {
            this.spellID = this.ReadUInt32();
        }

        public uint spellID { get; private set; }
    }
}
