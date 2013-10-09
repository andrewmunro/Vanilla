namespace Vanilla.World.Communication.Incoming.Character
{
    using System.Linq;

    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Network;

    internal sealed class PCCharDelete : PacketReader
    {
        #region Constructors and Destructors

        public PCCharDelete(byte[] data)
            : base(data)
        {
            var GUID = (int)ReadUInt64();

            this.Character = VanillaWorld.CharacterDatabase.Characters.Single(c => c.GUID == GUID);
        }

        #endregion

        #region Public Properties

        public Character Character { get; private set; }

        #endregion
    }
}