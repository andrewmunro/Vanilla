using Vanilla.Core.Config;
using Vanilla.Core.Extensions;
using Vanilla.Core.Network;
using Vanilla.Core.Opcodes;
using Vanilla.Login.Components.Realm.Constants;

namespace Vanilla.Login.Components.Realm.Packets.Outgoing
{
    internal sealed class PSRealmList : ServerPacket
    {
        #region Constructors and Destructors

        public PSRealmList()
            : base(LoginOpcodes.REALM_LIST)
        {
            Write((uint)0x0000);
            Write((byte)1);
            Write((uint)RealmType.PVP);
            Write((byte)0);
            this.WriteCString(Config.GetValue(ConfigSections.WORLD, ConfigValues.NAME));
            this.WriteCString(
                Config.GetValue(ConfigSections.WORLD, ConfigValues.IP) + ":"
                + Config.GetValue(ConfigSections.WORLD, ConfigValues.PORT));
            Write(Config.GetValue<float>(ConfigSections.WORLD, ConfigValues.POPULATION)); // Pop
            Write((byte)3); // Chars
            Write((byte)1); // time
            Write((byte)0); // time
            Write((ushort)0x0002);
        }

        #endregion
    }
}