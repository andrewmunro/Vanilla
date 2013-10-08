namespace Vanilla.Login.Communication.Incoming.Character
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
            var guid = (int)this.ReadUInt64();

            this.Character = VanillaLogin.CharacterDatabase.Characters.First(c => c.GUID == guid);
        }

        #endregion

        #region Public Properties

        public Character Character { get; private set; }

        #endregion
    }
}