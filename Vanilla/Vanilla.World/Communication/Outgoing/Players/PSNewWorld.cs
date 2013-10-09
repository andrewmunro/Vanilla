namespace Vanilla.World.Communication.Outgoing.Players
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public sealed class PSNewWorld : ServerPacket
    {
        #region Constructors and Destructors

        public PSNewWorld(int mapID, float x, float y, float z, float r)
            : base(WorldOpcodes.SMSG_NEW_WORLD)
        {
            Write(mapID);
            Write(x);
            Write(y);
            Write(z);
            Write(r);
        }

        #endregion
    }
}