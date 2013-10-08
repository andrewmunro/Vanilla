// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginSession.cs" company="">
//   
// </copyright>
// <summary>
//   The login session.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login
{
    using System;
    using System.IO;
    using System.Net.Sockets;

    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The login session.
    /// </summary>
    public class LoginSession : Session
    {
        #region Fields

        /// <summary>
        /// The session key.
        /// </summary>
        private byte[] SessionKey;

        /// <summary>
        /// The srp 6.
        /// </summary>
        private SRP6 srp6;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginSession"/> class.
        /// </summary>
        /// <param name="connectionID">
        /// The connection id.
        /// </param>
        /// <param name="connectionSocket">
        /// The connection socket.
        /// </param>
        public LoginSession(int connectionID, Socket connectionSocket)
            : base(connectionID, connectionSocket)
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string AccountName { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The disconnect.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public override void Disconnect(object obj = null)
        {
            base.Disconnect();
            VanillaLogin.Login.FreeConnectionID(this.pConnectionID);
        }

        /// <summary>
        /// The send packet.
        /// </summary>
        /// <param name="opcode">
        /// The opcode.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public void SendPacket(LoginOpcodes opcode, byte[] data)
        {
            this.SendPacket((byte)opcode, data);
        }

        /// <summary>
        /// The send packet.
        /// </summary>
        /// <param name="packet">
        /// The packet.
        /// </param>
        public void SendPacket(ServerPacket packet)
        {
            this.SendPacket((byte)packet.Opcode, packet.Packet);
        }

        /// <summary>
        /// The send packet.
        /// </summary>
        /// <param name="opcode">
        /// The opcode.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
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

        #endregion

        #region Methods

        /// <summary>
        /// The on packet.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        protected override void OnPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(
                LogType.Server, 
                this.ConnectionRemoteIP + " Data Recived - OpCode:" + opcode.ToString("X2") + " "
                + ((LoginOpcodes)opcode));

            var code = (LoginOpcodes)opcode;

            LoginDataRouter.CallHandler(this, code, data);
        }

        #endregion
    }
}