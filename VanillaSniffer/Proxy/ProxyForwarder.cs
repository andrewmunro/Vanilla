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
		private Socket from;
		private Socket to;
		private Thread _thread;

		public ProxyForwarder(Socket _from, Socket _to, String name)
		{

			from = _from;
			to = _to;
			_thread = new Thread(new ThreadStart(Start));
			_thread.Name = name;
			_thread.Start();
		}

		public byte[] readFrom()
		{
			byte[] rawDataBuffer = new byte[1024];
			NetworkStream ns = new NetworkStream(from);
			int readBytes = ns.Read(rawDataBuffer, 0, 1024);
			if (readBytes == 0) throw new SocketException();
			return BitConverter.GetBytes(readBytes);
		}

		private void Start()
		{
			Console.WriteLine("Thread '"+_thread.Name+" started!");
			try
			{
				while (true)
				{
					byte[] readBytes = readFrom();
					if (readBytes.Length > 0)
					{
						NetworkStream ns = new NetworkStream(to);
						ns.Write(readBytes, 0 ,1024);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		public void disconnect()
		{
			try {
				to.Disconnect(true);
			} catch (IOException e1) {
				Console.WriteLine(_thread.Name+" - Error while closing to-socket: "+e1);
			}
			try {
				from.Disconnect(true);
			} catch (IOException e1) {
				Console.WriteLine(_thread.Name + " - Error while closing from-socket: " + e1);
			}
		}
	}
}
