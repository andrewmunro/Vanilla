using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;
using Vanilla.World.Tools.Extensions;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    class PSTutorialFlags : ServerPacket
    {
        //TODO Write the uint ids of 8 tutorial values
        public PSTutorialFlags() : base((WorldOpcodes) WorldOpcodes.SMSG_TUTORIAL_FLAGS)
        {
            this.WriteNullUInt(8);
        }
    }
}
