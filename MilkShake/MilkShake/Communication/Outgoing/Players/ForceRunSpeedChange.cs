using System.IO;

namespace Milkshake.Communication.Outgoing.Players
{
    public class ForceRunSpeedChange: BinaryWriter
    {
        public ForceRunSpeedChange(float speed)  : base(new MemoryStream())
        {
            //Write((uint)state);
            //Write(grad);
            //Write((uint)sound);
        }

        public byte[] Packet { get { return (BaseStream as MemoryStream).ToArray(); } }
    }
}
