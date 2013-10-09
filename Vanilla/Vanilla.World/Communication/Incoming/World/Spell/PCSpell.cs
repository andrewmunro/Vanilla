namespace Vanilla.World.Communication.Incoming.World.Spell
{
    using Vanilla.Core.Network;

    internal class PCCastSpell : PacketReader
    {
        #region Constructors and Destructors

        public PCCastSpell(byte[] data)
            : base(data)
        {
            this.spellID = ReadUInt32();
            this.target = ReadCString();
        }

        #endregion

        #region Public Properties

        public uint spellID { get; private set; }

        public string target { get; private set; }

        #endregion
    }

    internal class PCCancelSpell : PacketReader
    {
        #region Constructors and Destructors

        public PCCancelSpell(byte[] data)
            : base(data)
        {
            this.spellID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint spellID { get; private set; }

        #endregion
    }
}