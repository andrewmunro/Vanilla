using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Player
{
    using Vanilla.Core.Opcodes;

    class PSEmote : ServerPacket
    {
        public PSEmote(uint emoteID, ulong GUID) : base(WorldOpcodes.SMSG_EMOTE)
        {
            Write(emoteID);
            Write(GUID);
        }
    }
}
