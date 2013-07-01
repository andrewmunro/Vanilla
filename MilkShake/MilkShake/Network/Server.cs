using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Milkshake.Game.Sessions;
using Milkshake.Tools;
using System.Net;

namespace Milkshake.Network
{
    public class MilkTCPListener
    {
        private Socket socketHandler;
        private int socketPort;
        private int maxConnections;
        private int acceptedConnections;

        private Dictionary<int, Session> activeConnections;

        public int Port { get { return socketPort; } }
        public int AcceptedConnections { get { return acceptedConnections; } }
        public int ConnectionCount { get { return activeConnections.Count; } }
        public int MaxConnections { get { return maxConnections; } }

        public bool Start(int _portNumber, int _maxConnections)
        {
            maxConnections = _maxConnections;
            socketPort = _portNumber;
            activeConnections = new Dictionary<int, Session>();
            socketHandler = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Log.Print(LogType.Server, "Starting up game server...");

            try
            {
                socketHandler.Bind(new IPEndPoint(IPAddress.Any, socketPort));
                socketHandler.Listen(25);
                socketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), socketHandler);

                Log.Print(LogType.Server, "Server Port: " + socketPort);
                Log.Print(LogType.Server, "Max connections: " + maxConnections);

                return true;
            }
            catch (Exception e)
            {
                Log.Print(LogType.Error, e.ToString());

                return false;
            }
        }

        private void ConnectionRequest(IAsyncResult _asyncResult)
        {
            Socket connectionSocket = ((Socket)_asyncResult.AsyncState).EndAccept(_asyncResult);

            if (activeConnections.Count == maxConnections)
            {
                Log.Print(LogType.Server, "User Disconnected - Server Full");

                connectionSocket.Close();
                socketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), socketHandler);
                return;
            }

            int connectionID = GetFreeID();

            activeConnections.Add(connectionID, GenerateSession(connectionID, connectionSocket));
            acceptedConnections++;

            socketHandler.BeginAccept(new AsyncCallback(ConnectionRequest), socketHandler);
        }

        public virtual Session GenerateSession(int connectionID, Socket connectionSocket)
        {
            return null;
        }

        private int GetFreeID()
        {
            for (int i = 0; i < maxConnections; i++)
            {
                if (!activeConnections.ContainsKey(i)) return i;
            }

            return -1;
        }

        public void FreeConnectionID(int _connectionID)
        {
            if (activeConnections.ContainsKey(_connectionID)) activeConnections.Remove(_connectionID);
        }

    }
}
