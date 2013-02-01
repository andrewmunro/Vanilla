using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace VanillaSniffer.Proxy
{
	class ProxyForwarder
	{
		private Socket _from;
		private Socket _to;
		private Thread _thread;
		private string _name;
		private NetworkStream _toStream;
		private NetworkStream _fromStream;

		public ProxyForwarder(Socket from, Socket to, String name)
		{
			_name = name;
			_from = from;
			_to = to;
			_toStream = new NetworkStream(_to);
			_fromStream = new NetworkStream(_from);
			_thread = new Thread(new ThreadStart(Recieve));
			_thread.Name = _name;
			_thread.Start();
		}

		private void Recieve()
		{
			try
			{
				Thread.Sleep(10);

				while (true)
				{
					Byte[] buffer = new byte[2048];
					int packetSize = _fromStream.Read(buffer, 0, _from.Available);
					if(packetSize == 0) break;
					byte [] packet = new byte[packetSize];
					Array.Copy(buffer, packet, packetSize);
					Send(packet);

					//TODO Handle packets :)
					//if (OnDataRecieved != null) OnDataRecieved(packet);
				}
				Disconnect();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void Send(byte[] data)
		{
			Console.WriteLine(_name+": Sending packet!");
			_toStream.Write(data, 0, data.Length);
		}


		public void Disconnect()
		{
			Console.WriteLine("<<< Client "+_name+" Disconnecting! >>>");
			try {
                _toStream.Close();
			} catch (IOException e1) {
				Console.WriteLine(_thread.Name+" - Error while closing to-socket: "+e1);
			}
			try {
                _fromStream.Close();
			} catch (IOException e1) {
				Console.WriteLine(_thread.Name + " - Error while closing _from-socket: " + e1);
			}
			//TODO This disconnects all clients :(
			if(ProxyManager.serverToClientThreads.Contains(this))
			{
				ProxyManager.serverToClientThreads.Remove(this);
			}

			if(ProxyManager.clientToServerThreads.Contains(this))
			{
				ProxyManager.clientToServerThreads.Remove(this);
			}
		}
	}
}
