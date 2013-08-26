using System;
using System.Collections.Generic;
using Milkshake.Communication.Incoming.World.Auth;
using Milkshake.Communication.Incoming.World.Movement;
using Milkshake.Communication.Outgoing.World.ActionBarButton;
using Milkshake.Game.Managers;
using Milkshake.Game.Sessions;
using Milkshake.Network;
using Milkshake.Tools;
using System.Net.Sockets;
using System.IO;
using Milkshake.Communication.Outgoing.World;
using Milkshake.Tools.Cryptography;
using Milkshake.Communication;
using Milkshake.Communication.Outgoing.Auth;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using Milkshake.Game.Constants.Login;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Incoming.World;
using Milkshake.Communication.Outgoing.World.Update;
using Milkshake.Tools.DBC;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using Milkshake.Game.Handlers;
using Milkshake.Game.Entitys;
using Milkshake.Communication.Outgoing.World.Player;
using Milkshake.Communication.Outgoing.Players;
using Milkshake.Game;

namespace Milkshake.Net
{
    public class WorldSession : Session
    {
        public UInt32 seed;
        public VanillaCrypt crypt;
        public Account Account;
        public Character Character;
        public PlayerEntity Entity;
        public uint OutOfSyncDelay;
        public uint Latancy;

        public WorldSession(int _connectionID, Socket _connectionSocket) : base(_connectionID, _connectionSocket)
        {
            sendPacket(WorldOpcodes.SMSG_AUTH_CHALLENGE, new byte[] { 0x33, 0x18, 0x34, 0xC8  } );
        }

        public override void Disconnect(object _obj = null)
        {
            base.Disconnect();
            MilkShake.world.FreeConnectionID(connectionID);

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

            sendData(((MemoryStream) writer.BaseStream).ToArray());
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