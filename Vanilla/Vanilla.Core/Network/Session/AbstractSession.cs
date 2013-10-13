using System;
using System.Net.Sockets;
using Vanilla.Core.Logging;
using Vanilla.Core.Network.Packet;

namespace Vanilla.Core.Network.Session
{
    public abstract class AbstractSession
    {
        public const int BufferSize = 2048 * 2;
        public const int TIMEOUT = 1000;

        public int pConnectionID { get; private set; }
        public Socket ConnectionSocket { get; private set; }
        public byte[] DataBuffer { get; private set; }

        public string ConnectionRemoteIP { get { return ConnectionSocket.RemoteEndPoint.ToString(); } }
        public int ConnectionID { get { return pConnectionID; } }

        public AbstractSession(int connectionID, Socket connectionSocket)
        {
            pConnectionID = connectionID;
            ConnectionSocket = connectionSocket;
            DataBuffer = new byte[BufferSize];

            try
            {
                ConnectionSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, DataArrival, null);
            }
            catch (SocketException)
            {
                Disconnect();
            }
        }

        public void SendData(byte[] send)
        {

            var buffer = new byte[send.Length];
            Buffer.BlockCopy(send, 0, buffer, 0, send.Length);

            try
            {
                ConnectionSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, delegate { }, null);
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

        public virtual void Disconnect(object obj = null)
        {
            try
            {
                Log.Print(LogType.Server, "User Disconnected");

                ConnectionSocket.Close();
            }
            catch (Exception socketException)
            {
                Log.Print(LogType.Error, socketException.ToString());
            }
        }

        internal virtual void DataArrival(IAsyncResult asyncResult)
        {
            var bytesRecived = 0;

            try { bytesRecived = ConnectionSocket.EndReceive(asyncResult); }
            catch (Exception) 
            { 
                //Client quit unexpectantly 
            }

            if (bytesRecived != 0)
            {
                var data = new byte[bytesRecived];
                Array.Copy(DataBuffer, data, bytesRecived);

                OnPacket(data);

                try
                {
                    ConnectionSocket.BeginReceive(DataBuffer, 0, DataBuffer.Length, SocketFlags.None, new AsyncCallback(DataArrival), null);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured recieving packet!");
                }
            }
            else
            {
                Disconnect();
            }
        }

        protected abstract void OnPacket(byte[] data);
    }
}
