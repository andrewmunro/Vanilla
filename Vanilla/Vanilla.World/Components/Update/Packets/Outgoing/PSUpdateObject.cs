using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;

namespace Vanilla.World.Components.Update.Packets.Outgoing
{
    public class PSUpdateObject : WorldPacket
    {
        
        public PSUpdateObject(List<byte[]> blocks, int hasTansport = 0)
            : base(WorldOpcodes.SMSG_UPDATE_OBJECT)
        {
            this.Write((uint)blocks.Count());
            this.Write((byte)hasTansport); // Has transport

            // Write each block
            blocks.ForEach(Write);
        }
    }
}