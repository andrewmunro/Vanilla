namespace Vanilla.Core.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;

    using Vanilla.Core.Logging;

    public class Server
    {
        public const int MAX_CONNECTION_QUEUE = 20;

        public Socket SocketHandler { get; protected set; }

        public Dictionary<int, Session> ActiveConnections { get; protected set; }

        public int Port { get; private set; }

        public int ConnectionsCount
        {
            get
            {
                return this.ActiveConnections.Count;
            }
        }

        public int MaxConnections { get; protected set; }

        public bool Start(int portNumber, int maxConnections)
        {
            this.MaxConnections = maxConnections;
            this.Port = portNumber;

            this.ActiveConnections = new Dictionary<int, Session>();

            this.SocketHandler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                this.SocketHandler.Bind(new IPEndPoint(IPAddress.Any, this.Port));
                this.SocketHandler.Listen(MAX_CONNECTION_QUEUE);
                this.SocketHandler.BeginAccept(this.ConnectionRequest, this.SocketHandler);

                Log.Print(LogType.Server, "Server listening on port " + this.Port);

                return true;
            }
            catch (Exception e)
            {
                Log.Print(LogType.Error, e.ToString());

                return false;
            }
        }

        public virtual Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            throw new Exception("Couldn't find free ID");
        }

        public void FreeConnectionID(int connectionID)
        {
            if (ActiveConnections.ContainsKey(connectionID))
            {
                this.ActiveConnections.Remove(connectionID);
            }
        }

        private int GenerateFreeID()
        {
            for (int i = 0; i < this.MaxConnections; i++)
            {
                if (!this.ActiveConnections.ContainsKey(i))
                {
                    return i;
                }
            }

            throw new Exception("Couldn't find free ID");
        }

        private void ConnectionRequest(IAsyncResult asyncResult)
        {
            Socket connectionSocket = ((Socket)asyncResult.AsyncState).EndAccept(asyncResult);

            if (this.ActiveConnections.Count == this.MaxConnections)
            {
                Log.Print(LogType.Server, "User Disconnected - Server Full");

                connectionSocket.Close();

                this.SocketHandler.BeginAccept(this.ConnectionRequest, this.SocketHandler);
                return;
            }

            int connectionID = GenerateFreeID();

            this.ActiveConnections.Add(connectionID, this.GenerateSession(connectionID, connectionSocket));

            this.SocketHandler.BeginAccept(this.ConnectionRequest, this.SocketHandler);
        }
    }
}
