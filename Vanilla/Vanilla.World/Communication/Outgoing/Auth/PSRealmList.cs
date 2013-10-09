namespace Vanilla.World.Communication.Outgoing.Auth
{
    #region

    using System;

    #endregion

    internal class PSRealmList : ServerPacket
    {
        #region Constructors and Destructors

        public PSRealmList()
            : base((LoginOpcodes)LoginOpcodes.REALM_LIST)
        {
            Write((uint)0x0000);
            Write((byte)1);
            Write((uint)RealmType.PVP);
            Write((byte)0);
            this.WriteCString(INI.GetValue(ConfigSections.WORLD, ConfigValues.NAME));
            this.WriteCString(
                INI.GetValue(ConfigSections.WORLD, ConfigValues.IP) + ":"
                + INI.GetValue(ConfigSections.WORLD, ConfigValues.PORT));
            Write((float)INI.GetValue<float>(ConfigSections.WORLD, ConfigValues.POPULATION)); // Pop
            Write((byte)3); // Chars
            Write((byte)1); // time
            Write((byte)0); // time
            Write((UInt16)0x0002);
        }

        #endregion
    }
}