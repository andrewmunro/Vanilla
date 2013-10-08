using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;
using Vanilla.World.Tools.Extensions;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    using Vanilla.Core.Opcodes;

    class PSAccountDataTimes : ServerPacket
    {
        public PSAccountDataTimes() : base((WorldOpcodes) WorldOpcodes.SMSG_ACCOUNT_DATA_TIMES)
        {
            this.WriteNullByte(128);
        }
    }
}
