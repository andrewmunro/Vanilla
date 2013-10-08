using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World
{
    using Vanilla.Core.Opcodes;

    public class LoginVerifyWorld : ServerPacket
    {
        public LoginVerifyWorld(int mapID, float X, float Y, float Z, float Rotation) : base(WorldOpcodes.SMSG_LOGIN_VERIFY_WORLD)
        {
            Write(mapID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(Rotation); // orientation
        }
    }
}
