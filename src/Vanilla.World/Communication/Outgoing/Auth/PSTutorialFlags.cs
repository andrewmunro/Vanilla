using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Extensions;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSTutorialFlags : ServerPacket
    {
        //TODO Write the uint ids of 8 tutorial values
        public PSTutorialFlags() : base(WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            this.WriteNullUInt(8);
        }
    }
}
