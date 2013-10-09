using System.IO;
using Vanilla.Core.Network;

namespace Vanilla.Core.Intercommunication
{
    public class VanillaRouter : PacketRouter<VanillaOpcodes, VanillaSession, BinaryReader>
    {
        public override VanillaOpcodes FetchOpcode(BinaryReader packet)
        {
            return (VanillaOpcodes) packet.ReadByte();
        }
    }
}
