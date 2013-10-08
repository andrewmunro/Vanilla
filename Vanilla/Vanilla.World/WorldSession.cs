using System;
using System.Net.Sockets;
using System.IO;
using Vanilla.Character.Database.Models;
using Vanilla.Core;
using Vanilla.World.Communication.Outgoing.Players;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Game.Managers;
using Vanilla.World.Network;
using Vanilla.World.Tools;
using Vanilla.World.Tools.Cryptography;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World
{
    using Vanilla.Core.Opcodes;

    public class WorldSession : Session
    {
        public UInt32 seed;
        public VanillaCrypt crypt;
        public Character.Database.Models.Character Character;
        public PlayerEntity Entity;
        public uint OutOfSyncDelay;
        public uint Latancy;

        public WorldSession(int _connectionID, Socket _connectionSocket) : base(_connectionID, _connectionSocket)
        {
            sendPacket(WorldOpcodes.SMSG_AUTH_CHALLENGE, new byte[] { 0x33, 0x18, 0x34, 0xC8  } );
        }

        public override void Disconnect(object obj = null)
        {
            base.Disconnect();
            VanillaWorld.World.FreeConnectionID(pConnectionID);

            World.DispatchOnPlayerDespawn(Entity);

            WorldServer.Sessions.Remove(this);
        }

        private byte[] encode(int size, int opcode)
        {
            int index = 0;
            int newSize = size + 2;
            byte[] header = new byte[4];
            if (newSize > 0x7FFF)
                header[index++] = (byte)(0x80 | (0xFF & (newSize >> 16)));

            header[index++] = (byte)(0xFF & (newSize >> 8));
            header[index++] = (byte)(0xFF & newSize);
            header[index++] = (byte)(0xFF & opcode);
            header[index] = (byte)(0xFF & (opcode >> 8));


            if (crypt != null) header = crypt.encrypt(header);

            return header;
        }

        public void sendPacket(int opcode, byte[] data)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            byte[] header = encode(data.Length, (int)opcode);

            writer.Write(header);
            writer.Write(data);

            Log.Print(LogType.Database, "Server -> Client [" + (WorldOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            SendData(((MemoryStream) writer.BaseStream).ToArray());
        }

        public void sendPacket(WorldOpcodes opcode, byte[] data)
        {
            sendPacket((int)opcode, data);
        }

        public void sendPacket(ServerPacket packet)
        {
            sendPacket((int)packet.Opcode, packet.Packet);
        }

        public void sendMessage(String message)
        {
            ChatManager.SendSytemMessage(this, message);
        }

        public void Teleport(int mapID, float X, float Y, float Z)
        {
            Character.MapID = mapID;
            Character.X = X;
            Character.Y = Y;
            Character.Z = Z;
            Character.Rotation = 0;
            DBCharacters.UpdateCharacter(Character);

            sendPacket(new PSTransferPending(mapID));
            sendPacket(new PSNewWorld(mapID, X, Y, Z, 0));
        }

        private void decode(byte[] header, out ushort length, out short opcode)
        {   
            if (crypt != null)
            {
                crypt.decrypt(header, 6);
            }

            PacketReader reader = new PacketReader(header);

            if (crypt == null)
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

        internal override void onPacket(byte[] data)
        {
                for (int index = 0; index < data.Length; index++)
                {
                    byte[] headerData = new byte[6];
                    Array.Copy(data, index, headerData, 0, 6);

                    ushort length = 0;
                    short opcode = 0;

                    decode(headerData, out length, out opcode);                

                    WorldOpcodes code = (WorldOpcodes)opcode;

                    byte[] packetDate = new byte[length];
                    Array.Copy(data, index + 6, packetDate, 0, length - 4);
                    Log.Print(LogType.Database, "Server <- Client [" + code + "] Packet Length: " + length);

                    WorldDataRouter.CallHandler(this, code, packetDate);

                    index += 2 + (length - 1);
                }
        }
        
        public void sendHexPacket(WorldOpcodes opcde, string hex)
        {
            string end = hex.Replace(" ", "").Replace("\n", "");

            byte[] data = Helper.HexToByteArray(end);

            sendPacket(opcde, data);
        }
    }
}