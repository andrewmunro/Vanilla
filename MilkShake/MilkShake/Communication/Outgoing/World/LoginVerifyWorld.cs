using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Milkshake.Communication.Outgoing.World
{
    public class LoginVerifyWorld : BinaryWriter
    {
        public LoginVerifyWorld(int mapID, float X, float Y, float Z, float Rotation) : base(new MemoryStream())
        {
            Write(mapID);
            Write(X);
            Write(Y);
            Write(Z);
            Write(Rotation); // orientation
        }

        public byte[] Packet { get { return (BaseStream as MemoryStream).ToArray(); } }
    }
}
