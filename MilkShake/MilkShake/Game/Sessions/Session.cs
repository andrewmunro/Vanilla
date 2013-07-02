using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Milkshake.Communication;
using Milkshake.Game.Handlers;
using Milkshake.Network;
using Milkshake.Tools;

namespace Milkshake.Game.Sessions
{
    public abstract class Session
    {
        public const int BUFFER_SIZE = 2048;
        public const int TIMEOUT = 1000;

        public int connectionID { get; private set; }
        public Socket connectionSocket { get; private set; }
        public byte[] dataBuffer { get; private set; }

        public string ConnectionRemoteIP { get { return connectionSocket.RemoteEndPoint.ToString(); } }
        public int ConnectionID { get { return connectionID; } }

        public Session(int _connectionID, Socket _connectionSocket)
        {
            connectionID = _connectionID;
            connectionSocket = _connectionSocket;
            dataBuffer = new byte[BUFFER_SIZE];

            connectionSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(dataArrival), null);
        }

        public void sendData(byte[] send)
        {
            byte[] buffer = new byte[send.Length];
            Buffer.BlockCopy(send, 0, buffer, 0, send.Length);

            Log.Print(LogType.Packet, "Sending [" + send[0].ToString("X2") + "] ");

            try
            {
                connectionSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, delegate(IAsyncResult result) { }, null);
            }
            catch (SocketException)
            {
                Disconnect();
            }
            catch (NullReferenceException)
            {
                Disconnect();
            }
            catch (ObjectDisposedException)
            {
                Disconnect();
            }
        }

        public virtual void Disconnect(object _obj = null)
        {
            try
            {
                Log.Print(LogType.Server, ConnectionRemoteIP + " User Disconnected");

                connectionSocket.Close();
                MilkShake.login.FreeConnectionID(connectionID);
            }
            catch (Exception socketException)
            {
                Log.Print(LogType.Error, socketException.ToString());
            }
        }

        internal abstract void onPacket(byte[] data);

        internal abstract void dataArrival(IAsyncResult _async);
    }
}
