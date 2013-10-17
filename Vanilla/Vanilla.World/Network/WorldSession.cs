using System.IO;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Extensions;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Network.Packet;

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

        public VanillaCrypt PacketCrypto { get; set; }

        public WorldSession(WorldServer server, int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket)
        {
            Server = server;

            // Connection Packet
            using (WorldPacket packet = new WorldPacket(WorldOpcodes.SMSG_AUTH_CHALLENGE))
            {
                packet.WriteBytes(new byte[] { 0x33, 0x18, 0x34, 0xC8 });
                SendPacket(packet);
            }
        }

        public override void SendPacket(PacketWriter packet)
        {
            byte[] endData = FinalisePacket(packet);

            Log.Print(LogType.Packet, "Server -> Client [" + packet.ParseOpcode() + "]");

            SendData(endData);
        }

        public override byte[] FinalisePacket(PacketWriter packet)
        {
            BinaryWriter endPacket = new BinaryWriter(new MemoryStream());
            byte[] header = this.Encode(packet.PacketData.Length, (int) packet.Opcode);

            endPacket.Write(header);
            endPacket.Write(packet.PacketData);

            return (endPacket.BaseStream as MemoryStream).ToArray();
        }

        private byte[] Encode(int size, int opcode)
        {
            var index = 0;
            var newSize = size + 2;
            var header = new byte[4];
            if (newSize > 0x7FFF)
            {
                header[index++] = (byte)(0x80 | (0xFF & (newSize >> 16)));
            }

            header[index++] = (byte)(0xFF & (newSize >> 8));
            header[index++] = (byte)(0xFF & newSize);
            header[index++] = (byte)(0xFF & opcode);
            header[index] = (byte)(0xFF & (opcode >> 8));


            if (this.PacketCrypto != null) header = this.PacketCrypto.encrypt(header);

            return header;
        }

        private void Decode(byte[] header)
        {
            if (PacketCrypto != null)
            {
                PacketCrypto.decrypt(header, 6);
            }

            ushort length;
            short opcode;

            if (PacketCrypto == null)
            {
                length = BitConverter.ToUInt16(new byte[] { header[1], header[0] }, 0);
                opcode = BitConverter.ToInt16(header, 2);
            }
            else
            {
                length = BitConverter.ToUInt16(new byte[] { header[1], header[0] }, 0);
                opcode = BitConverter.ToInt16(new byte[] { header[2], header[3] }, 0);
            }

            header[0] = BitConverter.GetBytes(opcode)[0];
            header[1] = BitConverter.GetBytes(opcode)[1];

            header[2] = BitConverter.GetBytes(length)[0];
            header[3] = BitConverter.GetBytes(length)[1];
        }

        protected override void OnPacket(byte[] data)
        {
            for (int index = 0; index < data.Length; index++)
            {
                this.Decode(data);

                ushort opcode = BitConverter.ToUInt16(data, 0);
                int length = BitConverter.ToInt16(data, 2);
                
                WorldOpcodes code = (WorldOpcodes)opcode;

                byte[] packetDate = new byte[length];
                Array.Copy(data, index, packetDate, 0, length);
                Log.Print(LogType.Database, "Server <- Client [" + code + "] Packet Length: " + length);

                Server.Router.CallHandler(this, packetDate);

                index += 2 + (length - 1);
            }
        }

        public void SendHexPacket(WorldOpcodes opcde, string hex)
        {
            /*
            string end = hex.Replace(" ", "").Replace("\n", "");

            byte[] data = Utils.HexToByteArray(end);

            this.SendPacket(opcde, data);*/
            throw  new Exception("no");
        }
    }
}