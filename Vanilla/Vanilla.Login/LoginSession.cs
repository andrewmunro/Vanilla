using System;
using System.IO;
using System.Net.Sockets;
using Vanilla.Core;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Logging;
using Vanilla.Core.Network;

namespace Vanilla.Login
{
    public class LoginSession : Session
    {
        public SRP6 Srp6;
        public String accountName { get; set; }
        public byte[] SessionKey;

        public LoginSession(int _connectionID, Socket _connectionSocket) : base(_connectionID, _connectionSocket)
        {
            
        }

        public override void Disconnect(object obj = null) 
        {
            base.Disconnect();
            VanillaLogin.Login.FreeConnectionID(pConnectionID);
        }

        public void SendPacket(LoginOpcodes opcode, byte[] data)
        {
            SendPacket((byte)opcode, data);
        }

        public void SendPacket(ServerPacket packet)
        {
            SendPacket((byte)packet.Opcode, packet.Packet);
        }

        public void SendPacket(byte opcode, byte[] data)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            writer.Write(opcode);
            writer.Write((ushort)data.Length);
            writer.Write(data);

            Log.Print(LogType.Database, pConnectionID + "Server -> Client [" + (LoginOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            SendData(((MemoryStream)writer.BaseStream).ToArray());
        }


        internal override void OnPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(LogType.Server, ConnectionRemoteIP + " Data Recived - OpCode:" + opcode.ToString("X2") + " " + ((LoginOpcodes)opcode));

            LoginOpcodes code = (LoginOpcodes)opcode;

            LoginDataRouter.CallHandler(this, code, data);
        }
    }
}
