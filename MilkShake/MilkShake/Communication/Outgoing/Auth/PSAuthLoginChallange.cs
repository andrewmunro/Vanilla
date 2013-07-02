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
    class PSAuthLoginChallange : ServerPacket
    {
        public PSAuthLoginChallange(SRP6 Srp6) : base(LoginOpcodes.AUTH_LOGIN_CHALLENGE)
        {
            Write((byte)0);
            Write((byte)0);
            Write((byte)AccountStatus.Ok);
            Write(Srp6.B);
            Write((byte)1);
            Write(Srp6.g[0]);
            Write((byte)Srp6.N.Length);
            Write(Srp6.N);
            Write(Srp6.salt);
            this.WriteNull(17);
        }
    }
}
