using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Constants.Login;
using Vanilla.World.Network;
using Vanilla.World.Tools.Cryptography;

namespace Vanilla.World.Communication.Outgoing.Auth
{
    class PSAuthLoginProof : ServerPacket
    {
        public PSAuthLoginProof(SRP6 Srp6) : base((LoginOpcodes) LoginOpcodes.AUTH_LOGIN_PROOF)
        {
            Write((byte)1);
            Write((byte)AccountStatus.Ok);
            Write(Srp6.M2);
            this.WriteNullByte(4);
        }
    }
}
