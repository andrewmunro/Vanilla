namespace Vanilla.World.Components.Character.Packets.Outgoing
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    internal class PSCharDelete : WorldPacket
    {
        public PSCharDelete(LoginErrorCode code)
            : base(WorldOpcodes.SMSG_CHAR_CREATE)
        {
            this.Write((byte)code);
        }
    }
}