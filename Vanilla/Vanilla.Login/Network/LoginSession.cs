namespace Vanilla.Login.Network
{
    using System;
    using System.Net.Sockets;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.Session;
    using Vanilla.Core.Opcodes;

    public class LoginSession : Session
    {
        public LoginServer Server;

        public Authenticator Authenticator;

        public string AccountName { get; set; }

        public LoginSession(LoginServer server, int connectionID, Socket connectionSocket) : base(connectionID, connectionSocket)
        {
            Server = server;
        }
        
        protected override void OnPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(LogType.Packet, "Server <- Client [" + (LoginOpcodes)opcode + "]");

            Server.OnPacket(this, data);
        }

    }
}