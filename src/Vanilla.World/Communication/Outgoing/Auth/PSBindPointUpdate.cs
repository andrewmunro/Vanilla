using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSBindPointUpdate : ServerPacket
    {
        public PSBindPointUpdate() : base(WorldOpcodes.SMSG_BINDPOINTUPDATE)
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
