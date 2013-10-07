namespace Vanilla.Core.Network
{
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
