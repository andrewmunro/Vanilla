using System;
using System.Text;
using System.Net.Sockets;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Auth;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Login;
using Milkshake.Game.Handlers;
using Milkshake.Network;
using Milkshake.Tools;
using System.Security.Cryptography;
using System.IO;
using Milkshake.Tools.Config;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Extensions;

namespace Milkshake.Game.Sessions
{
    public class LoginSession : Session
    {
        public SRP6 Srp6;
        public String accountName { get; set; }
        public byte[] SessionKey;

        public LoginSession(int _connectionID, Socket _connectionSocket) : base(_connectionID, _connectionSocket)
        {
            
        }

        public override void Disconnect(object _obj = null) 
        {
            base.Disconnect();
            MilkShake.login.FreeConnectionID(connectionID);
        }

        public void sendPacket(LoginOpcodes opcode, byte[] data)
        {
            sendPacket((byte)opcode, data);
        }

        public void sendPacket(ServerPacket packet)
        {
            sendPacket((byte)packet.Opcode, packet.Packet);
        }

        public void sendPacket(byte opcode, byte[] data)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write(opcode);
            writer.Write((ushort)data.Length);
            writer.Write(data);

            Log.Print(LogType.Database, connectionID + "Server -> Client [" + (LoginOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            sendData(((MemoryStream)writer.BaseStream).ToArray());
        }


        internal override void onPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(LogType.Server, ConnectionRemoteIP + " Data Recived - OpCode:" + opcode.ToString("X2") + " " + ((LoginOpcodes)opcode));

            LoginOpcodes code = (LoginOpcodes)opcode;

            LoginDataRouter.CallHandler(this, code, data);
        }
    }
}
