using System.Linq;
using Vanilla.World.Network;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World.Communication.Incoming.Character
{
    class PCCharDelete : PacketReader
    {
        public Tools.Database.Tables.Character Character { get; private set; }

        public PCCharDelete(byte[] data) : base(data)
        {
            int GUID = (int)ReadUInt64();

            Character = DBCharacters.Characters.First(c => c.GUID == GUID);
        }
    }
}
