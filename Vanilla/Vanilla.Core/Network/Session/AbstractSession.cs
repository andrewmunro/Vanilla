namespace Vanilla.Core.Network.Session
{
    using System;
    using System.Net.Sockets;

    using Vanilla.Core.Events;
    using Vanilla.Core.Logging;

    public abstract class AbstractSession
    {
        public const int BufferSize = 2048 * 2;
        public const int TIMEOUT = 1000;

        public Socket ConnectionSocket { get; private set; }

        public byte[] DataBuffer { get; private set; }

        public string ConnectionRemoteIP { get { return ConnectionSocket.RemoteEndPoint.ToString(); } }

        public int ConnectionID { get; private set; }

        public event SessionEvent OnSessionDisconnect;

        public AbstractSession(int connectionID, Socket connectionSocket)
        {
            this.ConnectionID = connectionID;
            this.ConnectionSocket = connectionSocket;
            this.DataBuffer = new byte[BufferSize];

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

        public virtual void Disconnect()
        {
            try
            {
                Log.Print(LogType.Server, "User Disconnected");

                ConnectionSocket.Close();

                //Null Check for login session.
                if(OnSessionDisconnect != null) OnSessionDisconnect(this);
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

        public abstract int HeaderLength { get; }
    }
}
