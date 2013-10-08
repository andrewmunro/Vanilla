namespace Vanilla.Core.Network
{
    using Vanilla.Core.Constants;
    using Vanilla.Core.Opcodes;

    public class WorldPacket : Packet
    {
        public WorldPacket(byte[] data)
            : base(data)
        { }

        public WorldPacket(LoginOpcodes opCode)
            : base(opCode.Parse(), (byte)opCode)
        { }
    }
}
