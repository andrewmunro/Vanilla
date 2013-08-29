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
        public const int BUFFER_SIZE = 2048 * 2;
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

        public void sendData(ServerPacket packet)
        {
            sendData(packet.Packet);
        }

        public virtual void Disconnect(object _obj = null)
        {
            try
            {
                Log.Print(LogType.Server, "User Disconnected");

                connectionSocket.Close();
                MilkShake.login.FreeConnectionID(connectionID);
            }
            catch (Exception socketException)
            {
                Log.Print(LogType.Error, socketException.ToString());
            }
        }

        internal virtual void dataArrival(IAsyncResult _asyncResult)
        {
            int bytesRecived = 0;

            try { bytesRecived = connectionSocket.EndReceive(_asyncResult); }
            catch (Exception) 
            { 
                //Client quit unexpectantly 
            }

            if (bytesRecived != 0)
            {
                byte[] data = new byte[bytesRecived];
                Array.Copy(dataBuffer, data, bytesRecived);

                onPacket(data);

                try
                {
                    connectionSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(dataArrival), null);
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

        internal abstract void onPacket(byte[] data);
    }
}
