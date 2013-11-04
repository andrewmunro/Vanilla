namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSLoginVerifyWorld : WorldPacket
    {
        public PSLoginVerifyWorld(int mapID, float X, float Y, float Z, float Rotation)
            : base(WorldOpcodes.SMSG_LOGIN_VERIFY_WORLD)
        {
            this.Write(mapID);
            this.Write(X);
            this.Write(Y);
            this.Write(Z);
            this.Write(Rotation); // orientation
        }
    }
}