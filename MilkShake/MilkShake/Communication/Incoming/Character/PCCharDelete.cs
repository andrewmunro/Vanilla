using System.Linq;
using Milkshake.Network;
using Milkshake.Tools.Database.Helpers;

namespace Milkshake.Communication.Incoming.Character
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
