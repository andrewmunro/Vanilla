using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Login;
using Milkshake.Network;
using Milkshake.Tools.Config;
using Milkshake.Tools.Extensions;

namespace Milkshake.Communication.Outgoing.Auth
{
    class PSRealmList : ServerPacket
    {
        public PSRealmList() : base(LoginOpcodes.REALM_LIST)
        {
            Write((uint)0x0000);
            Write((byte)1);
            Write((uint)RealmType.PVP);
            Write((byte)0);
            this.WriteCString(INI.GetValue(ConfigValues.WORLD, ConfigValues.NAME));
            this.WriteCString(INI.GetValue(ConfigValues.WORLD, ConfigValues.IP) + ":" + INI.GetValue(ConfigValues.WORLD, ConfigValues.PORT));
            Write((float)INI.GetValue<float>(ConfigValues.WORLD, ConfigValues.POPULATION)); // Pop
            Write((byte)3); // Chars
            Write((byte)1); // time
            Write((byte)0); // time
            Write((UInt16)0x0002); 
        }
    }
}
