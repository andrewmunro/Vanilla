namespace Vanilla.World.Network
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;

    public class WorldRouter : Router<WorldOpcodes, WorldSession, PacketReader>
    {
        public override WorldOpcodes FetchOpcode(PacketReader packet)
        {
            return (WorldOpcodes)packet.ReadUInt16();
        }
    }
}