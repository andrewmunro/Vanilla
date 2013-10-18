namespace Vanilla.Server
{
    using System;
    using System.Net.Sockets;
    using System.Text;

    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;

    public class BotClient
    {
        private TcpClient tcpClient = null;
        private int _port;

        public BotClient(int port)
        {
            _port = port;
        }

        public void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient(AddressFamily.InterNetwork);

                tcpClient.BeginConnect("127.0.0.1", _port, new AsyncCallback(ConnectCallback), tcpClient);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }


        private void ConnectCallback(IAsyncResult result)
        {
            Console.WriteLine("Connected!");
            try
            {
                NetworkStream networkStream = tcpClient.GetStream();

                PacketWriter writer = new PacketWriter((byte)LoginOpcodes.AUTH_LOGIN_BOT, Core.Constants.PacketHeaderType.AuthCmsg);
                writer.Write((byte)LoginOpcodes.AUTH_LOGIN_BOT);
                writer.WriteCString("Dave");

                byte[] packetData = writer.PacketData;

                networkStream.Write(packetData, 0, packetData.Length);
                
                byte[] buffer = new byte[tcpClient.ReceiveBufferSize];

                networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
            }
            catch (Exception ex)
            {
                //Logger.WriteLog(LogLevel.Error,"ex.Message);
            }
        }



        /// Callback for Read operation
        private void ReadCallback(IAsyncResult result)
        {
            NetworkStream networkStream;

            try
            {

                networkStream = tcpClient.GetStream();

            }

            catch
            {
                //Logger.WriteLog(LogLevel.Warning,"ex.Message);
                return;

            }

            byte[] buffer = result.AsyncState as byte[];

            string data = ASCIIEncoding.ASCII.GetString(buffer, 0, buffer.Length);

            Console.WriteLine(data);


            networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);

        }
    }
}
