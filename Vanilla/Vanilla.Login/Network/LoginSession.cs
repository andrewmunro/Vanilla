namespace Vanilla.Login
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net.Sockets;

    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    public class LoginSession : Session
    {
        public byte[] SessionKey;
        public SRP6 Srp6;

        public LoginSession(int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket) { }
        public string AccountName { get; set; }

        public override void Disconnect(object obj = null)
        {
            base.Disconnect();
            VanillaLogin.Server.FreeConnectionID(this.pConnectionID);
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

            Log.Print(
                LogType.Database, 
                this.pConnectionID + "Server -> Client [" + (LoginOpcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            this.SendData(((MemoryStream)writer.BaseStream).ToArray());
        }

        protected override void OnPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(
                LogType.Server,
                this.ConnectionRemoteIP + " Data Recived - OpCode:" + opcode.ToString("X2") + " "
                + ((LoginOpcodes)opcode));

            var code = (LoginOpcodes)opcode;

            LoginRouter.CallHandler(this, code, data);
        }

    }
}