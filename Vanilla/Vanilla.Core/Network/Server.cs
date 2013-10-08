using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Vanilla.Core.Logging;

namespace Vanilla.Core.Network
{
    public class Server
    {
        public const int MAX_CONNECTION_QUEUE = 20;

        public Socket SocketHandler { get; protected set; }
        public Dictionary<int, Session> ActiveConnections { get; protected set; }

        public int Port { get; private set; }
        public int ConnectionsCount { get { return ActiveConnections.Count; } }
        public int MaxConnections { get; protected set; }

        public bool Start(int portNumber, int maxConnections)
        {
            MaxConnections = maxConnections;
            Port = portNumber;

            ActiveConnections = new Dictionary<int, Session>();

            SocketHandler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                SocketHandler.Bind(new IPEndPoint(IPAddress.Any, Port));
                SocketHandler.Listen(MAX_CONNECTION_QUEUE);
                SocketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), SocketHandler);

                Log.Print(LogType.Server, "Server listening on port " + Port);

                return true;
            }
            catch (Exception e)
            {
                Log.Print(LogType.Error, e.ToString());

                return false;
            }
        }

        private void ConnectionRequest(IAsyncResult asyncResult)
        {
            Socket connectionSocket = ((Socket)asyncResult.AsyncState).EndAccept(asyncResult);

            if (ActiveConnections.Count == MaxConnections)
            {
                Log.Print(LogType.Server, "User Disconnected - Server Full");

                connectionSocket.Close();
                
                SocketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), SocketHandler);
                return;
            }

            int connectionID = GenerateFreeID();
            ActiveConnections.Add(connectionID, GenerateSession(connectionID, connectionSocket));

            SocketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), SocketHandler);
        }

        public virtual Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            throw new Exception("Couldn't find free ID");
        }

        private int GenerateFreeID()
        {
            for (int i = 0; i < MaxConnections; i++)
            {
                if (!ActiveConnections.ContainsKey(i)) return i;
            }

            throw new Exception("Couldn't find free ID");
        }

        public void FreeConnectionID(int _connectionID)
        {
            if (ActiveConnections.ContainsKey(_connectionID)) ActiveConnections.Remove(_connectionID);
        }

    }
}
