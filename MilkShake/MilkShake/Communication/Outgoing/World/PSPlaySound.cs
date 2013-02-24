using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World
{
    internal class PSPlaySound : ServerPacket
    {
        public PSPlaySound(uint soundID) : base(Opcodes.SMSG_PLAY_SOUND)
        {
            Write(soundID);
        }
    }
}
