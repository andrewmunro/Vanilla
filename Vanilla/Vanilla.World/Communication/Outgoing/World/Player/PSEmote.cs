namespace Vanilla.World.Communication.Outgoing.World.Player
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    internal class PSEmote : ServerPacket
    {
        #region Constructors and Destructors

        public PSEmote(uint emoteID, ulong GUID)
            : base(WorldOpcodes.SMSG_EMOTE)
        {
            Write(emoteID);
            Write(GUID);
        }

        #endregion
    }
}