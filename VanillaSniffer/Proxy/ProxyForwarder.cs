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
	public class ProxyForwarder
	{
		private Socket _from;
		private Socket _to;
		private Thread _thread;
		private string _name;
		private NetworkStream _toStream;
		private NetworkStream _fromStream;
	    private bool _disconnecting = false;
        public event DataRecived OnDataRecived;

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
                    // Only disconnect if two packets of 0 size are sent in a row
                    if (packetSize == 0)
                    {
                        if (_disconnecting) break;
                        else _disconnecting = true;
                    }
                    else
                    {
                        _disconnecting = false;
                        byte[] packet = new byte[packetSize];
                        Array.Copy(buffer, packet, packetSize);
                        //Send(packet);
                        if (OnDataRecived != null) OnDataRecived(packet);
                    }             
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
			_toStream.Write(data, 0, data.Length);
		}


		public void Disconnect()
		{
            //TODO Fix disconnects :(
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
