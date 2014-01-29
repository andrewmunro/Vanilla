namespace Vanilla.World.Network
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Network.Session;
    using Vanilla.Core.Opcodes;
    using Vanilla.Core.Tools;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.Login.Models;
    using Vanilla.World.Components.Chat;
    using Vanilla.World.Game.Entity.Object.Player;
    using Vanilla.World.Game.Update;

    public class WorldSession : Session
    {
        public WorldServer Server { get; set; }

        public override int HeaderLength { get { return 6; } }

        public Account Account { get; set; }

        public PlayerEntity Player { get; set; }

        public VanillaCrypt PacketCrypto { get; set; }

        public UpdatePacketBuilder UpdatePacketBuilder { get; set; }

        public VanillaWorld Core { get; private set; }

        public uint OutOfSyncDelay { get; set; }

        public WorldSession(WorldServer server, VanillaWorld core, int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket)
        {
            Server = server;
            Core = core;

            UpdatePacketBuilder = new UpdatePacketBuilder(this);

            // Connection Packet
            using (WorldPacket packet = new WorldPacket(WorldOpcodes.SMSG_AUTH_CHALLENGE))
            {
                packet.WriteBytes(new byte[] { 0x33, 0x18, 0x34, 0xC8 });
                SendPacket(packet);
            }
        }

        public override void SendPacket(PacketWriter packet)
        {
            LogPacket(packet);

            byte[] endData = FinalisePacket(packet);

            Log.Print(LogType.Packet, "Server -> Client [" + packet.ParseOpcode() + "]");

            SendData(endData);
        }

        public override byte[] FinalisePacket(PacketWriter packet)
        {
            BinaryWriter endPacket = new BinaryWriter(new MemoryStream());
            byte[] header = this.Encode(packet.PacketData.Length, packet.Opcode);

            endPacket.Write(header);
            endPacket.Write(packet.PacketData);

            var data = (endPacket.BaseStream as MemoryStream).ToArray();

            return data;
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

        private void LogPacket(PacketWriter packet)
        {
            try
            {
                var filename = "packetlog.txt";
                if (!File.Exists(filename)) File.Create(filename).Close();

                using (StreamWriter w = File.AppendText(filename))
                {
                    w.WriteLine(DateTime.Now.ToString("yyyy-M-d H:mm:ss"));
                    w.WriteLine("Length: " + packet.PacketData.Length);
                    w.WriteLine("Opcode: " + packet.ParseOpcode());
                    w.WriteLine("Data: ");
                    w.Write(Utils.ByteArrayToHex(packet.PacketData));
                    w.WriteLine();
                    w.WriteLine();
                }
            }
            catch (Exception)
            {
            }
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
            try
            {
                for (int index = 0; index < data.Length; index++)
                {
                    byte[] headerData = new byte[6];
                    Array.Copy(data, index, headerData, 0, 6);
                    this.Decode(headerData);
                    Array.Copy(headerData, 0, data, index, 6);

                    ushort opcode = BitConverter.ToUInt16(headerData, 0);
                    int length = BitConverter.ToInt16(headerData, 2);

                    WorldOpcodes code = (WorldOpcodes)opcode;

                    byte[] packetData = new byte[length + 2];
                    Array.Copy(data, index, packetData, 0, length + 2);
                    Log.Print(LogType.Database, "Server <- Client [" + code + "] Packet Length: " + length);

                    Server.Router.CallHandler(this, packetData);

                    index += 2 + (length - 1);
                }
            }
            catch (Exception e)
            {
                Log.Print(LogType.Error, e.ToString() + " " + e.InnerException);
            }
        }

        public void SendHexPacket(WorldOpcodes opcde, string hex)
        {
            
            string end = hex.Replace(" ", "").Replace("\n", "");

            byte[] data = Utils.HexToByteArray(end);

            WorldPacket packet = new WorldPacket(opcde);
            packet.Write(data);

            this.SendPacket(packet);
            //throw new Exception("no");
        }

        public void SendMessage(String message)
        {
            Core.GetComponent<ChatMessageComponent>().SendSytemMessage(this, message);
        }

        public void Update()
        {
            UpdatePacketBuilder.Update();
        }
    }
}