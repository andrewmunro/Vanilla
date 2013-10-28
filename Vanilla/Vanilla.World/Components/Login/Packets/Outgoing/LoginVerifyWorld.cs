using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public sealed class PSLoginVerifyWorld : WorldPacket
    {
        #region Constructors and Destructors

        public PSLoginVerifyWorld(int mapID, float X, float Y, float Z, float Rotation)
            : base(WorldOpcodes.SMSG_LOGIN_VERIFY_WORLD)
        {
            Write(mapID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(Rotation); // orientation
        }

        #endregion
    }
}