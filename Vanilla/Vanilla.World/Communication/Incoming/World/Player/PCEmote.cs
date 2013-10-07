using Vanilla.World.Network;

namespace Vanilla.World.Communication.Incoming.World.Player
{
    public class PCEmote : PacketReader
    {   
        public uint EmoteID { get; private set; }

        public PCEmote(byte[] data) : base(data)
        {
            EmoteID = ReadUInt32();
        }
    }
}
