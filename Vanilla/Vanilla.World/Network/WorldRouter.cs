namespace Vanilla.World.Network
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;

    public class WorldRouter : Router<WorldOpcodes, WorldSession, PacketReader>
    {
        public override WorldOpcodes FetchOpcode(PacketReader packet)
        {
            WorldOpcodes opcode = (WorldOpcodes)packet.ReadUInt16();
            packet.ReadBytes(2); // Length

            return opcode;
        }
    }
}