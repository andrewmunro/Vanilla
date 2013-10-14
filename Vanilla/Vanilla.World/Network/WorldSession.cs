namespace Vanilla.World.Network
{
    using System;
    using System.Net.Sockets;

    using Vanilla.Character.Database.Models;
    using Vanilla.Core;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.Session;
    using Vanilla.Core.Opcodes;

    public class WorldSession : Session
    {
        public WorldServer Server { get; set; }

        public Character Character { get; set; }

        public WorldSession(WorldServer server, int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket)
        {
            Server = server;
        }

        private void Decode(byte[] header, out ushort length, out short opcode)
        {
            if (this.crypt != null)
            {
                this.crypt.decrypt(header, 6);
            }

            if (this.crypt == null)
            {
                length = BitConverter.ToUInt16(new byte[] { header[1], header[0] }, 0);
                opcode = BitConverter.ToInt16(header, 2);
            }
            else
            {
                length = BitConverter.ToUInt16(new byte[] { header[1], header[0] }, 0);
                opcode = BitConverter.ToInt16(new byte[] { header[2], header[3] }, 0);
            }
        }

        protected override void OnPacket(byte[] data)
        {
            for (int index = 0; index < data.Length; index++)
            {
                byte[] headerData = new byte[6];
                Array.Copy(data, index, headerData, 0, 6);

                ushort length = 0;
                short opcode = 0;

                this.Decode(headerData, out length, out opcode);

                WorldOpcodes code = (WorldOpcodes)opcode;

                byte[] packetDate = new byte[length];
                Array.Copy(data, index + 6, packetDate, 0, length - 4);
                Log.Print(LogType.Database, "Server <- Client [" + code + "] Packet Length: " + length);

                WorldDataRouter.CallHandler(this, code, packetDate);

                index += 2 + (length - 1);
            }
        }

        public void SendHexPacket(WorldOpcodes opcde, string hex)
        {
            string end = hex.Replace(" ", "").Replace("\n", "");

            byte[] data = Utils.HexToByteArray(end);

            this.SendPacket(opcde, data);
        }
    }
}