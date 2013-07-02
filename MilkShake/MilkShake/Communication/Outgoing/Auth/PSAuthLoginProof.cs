using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants;
using Milkshake.Network;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.Extensions;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSAuthLoginProof : ServerPacket
    {
        public PSAuthLoginProof(SRP6 Srp6) : base(LoginOpcodes.AUTH_LOGIN_PROOF)
        {
            Write((byte)1);
            Write((byte)AccountStatus.Ok);
            Write(Srp6.M2);
            this.WriteNull(4);
        }
    }
}
