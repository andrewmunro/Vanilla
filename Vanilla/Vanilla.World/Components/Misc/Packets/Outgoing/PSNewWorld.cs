namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSNewWorld : WorldPacket
    {
        public PSNewWorld(int mapID, float x, float y, float z, float r)
            : base(WorldOpcodes.SMSG_NEW_WORLD)
        {
            this.Write(mapID);
            this.Write(x);
            this.Write(y);
            this.Write(z);
            this.Write(r);
        }
    }
}