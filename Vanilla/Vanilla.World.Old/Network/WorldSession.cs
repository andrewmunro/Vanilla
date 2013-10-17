namespace Vanilla.World.Network
{
    using System;
    using System.IO;
    using System.Net.Sockets;

    using Database.Character.Models;
    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Network.Session;
    using Vanilla.Core.Opcodes;
    using Vanilla.Login.Database.Models;
    using Vanilla.World.Game.Entitys;
    using Vanilla.World.Game.Handlers;
    using Vanilla.World.Game.Managers;

    public class WorldSession : AbstractSession
    {
        public UInt32 seed;
        public VanillaCrypt crypt;
        public Character Character;
        public PlayerEntity Entity;
        public uint OutOfSyncDelay;
        public uint Latancy;

        public WorldSession(int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket)
        {
            this.SendPacket(WorldOpcodes.SMSG_AUTH_CHALLENGE, new byte[] { 0x33, 0x18, 0x34, 0xC8 });
        }

        public Account Account { get; set; }

        public override void Disconnect(object obj = null)
        {
            base.Disconnect(obj);
            VanillaWorld.WorldServer.FreeConnectionID(this.pConnectionID);
            VanillaWorld.World.DispatchOnPlayerDespawn(this.Entity);
            WorldServer.Sessions.Remove(this);
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


            if (this.crypt != null) header = this.crypt.encrypt(header);

            return header;
        }

        public void SendPacket(int opcode, byte[] data)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            byte[] header = this.Encode(data.Length, (int)opcode);

            
            writer.Write(header);
            writer.Write(data);

            Log.Print(LogType.Database, "Server -> Client [" + (WorldOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            this.SendData(((MemoryStream) writer.BaseStream).ToArray());
        }

        public void SendPacket(WorldOpcodes opcode, byte[] data)
        {
            this.SendPacket((int)opcode, data);
        }

        public void SendPacket(WorldPacket packet)
        {
            this.SendPacket((int)packet.Opcode, packet.Packet);
        }

        public void sendMessage(String message)
        {
            ChatMessageComponent.SendSytemMessage(this, message);
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

                ushort length;
                short opcode;

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