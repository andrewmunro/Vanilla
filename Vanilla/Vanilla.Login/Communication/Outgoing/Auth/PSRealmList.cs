// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSRealmList.cs" company="">
//   
// </copyright>
// <summary>
//   The ps realm list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login.Communication.Outgoing.Auth
{
    using System;

    using Vanilla.Core.Network;

    /// <summary>
    /// The ps realm list.
    /// </summary>
    internal class PSRealmList : ServerPacket
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRealmList"/> class.
        /// </summary>
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