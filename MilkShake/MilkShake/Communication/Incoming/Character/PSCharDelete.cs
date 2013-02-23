using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;

namespace Milkshake.Communication.Incoming.Character
{
    class PCCharDelete : PacketReader
    {
        public Tools.Database.Character Character { get; private set; }

        public PCCharDelete(byte[] data) : base(data)
        {
            int GUID = (int)ReadUInt64();

            Character = DBCharacters.Characters.First(c => c.GUID == GUID);
        }
    }
}
