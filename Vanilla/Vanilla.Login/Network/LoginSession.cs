using System;
using System.IO;
using System.Net.Sockets;
using Vanilla.Core;
using Vanilla.Core.Cryptography;
using Vanilla.Core.Logging;
using Vanilla.Core.Network;
using Vanilla.Core.Opcodes;

namespace Vanilla.Login.Network
{
    public class LoginSession : Session
    {
        public LoginServer Server;

        public byte[] SessionKey;
        public SRP6 Srp6;

        public LoginSession(LoginServer server, int connectionID, Socket connectionSocket)
            : base(connectionID, connectionSocket)
        {
            Server = server;
        }

        public string AccountName { get; set; }

        public override void Disconnect(object obj = null)
        {
            base.Disconnect();
            //VanillaLogin.Server.FreeConnectionID(this.pConnectionID);
        }

        public void SendPacket(LoginOpcodes opcode, byte[] data)
        {
            this.SendPacket((byte)opcode, data);
        }

        public void SendPacket(ServerPacket packet)
        {
            this.SendPacket((byte)packet.Opcode, packet.Packet);
        }

        public void SendPacket(byte opcode, byte[] data)
        {
            var writer = new BinaryWriter(new MemoryStream());
            writer.Write(opcode);
            writer.Write((ushort)data.Length);
            writer.Write(data);

            Log.Print(LogType.Database, "Server -> Client [" + (LoginOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            this.SendData(((MemoryStream)writer.BaseStream).ToArray());
        }

        protected override void OnPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(
                LogType.Server,
                string.Format("{0} Data Recived - OpCode:{1} {2}", this.ConnectionRemoteIP, opcode.ToString("X2"), (LoginOpcodes)opcode));

            Server.OnPacket(this, data);
        }

    }
}