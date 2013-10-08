using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    using Vanilla.Core.Opcodes;

    class PSBindPointUpdate : ServerPacket
    {
        public PSBindPointUpdate() : base((WorldOpcodes) WorldOpcodes.SMSG_BINDPOINTUPDATE)
        {
            //TODO Pull hearthstone info from DB.
            Write((float)1); //X
            Write((float)1); //Y
            Write((float)1); //Z
            Write((uint)1); //MAPID
            Write((short)1); //AREAID
        }
    }
}
