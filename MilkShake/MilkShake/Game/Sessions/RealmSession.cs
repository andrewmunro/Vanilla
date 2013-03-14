using System;
using System.Text;
using System.Net.Sockets;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Auth;
using Milkshake.Game.Constants;
using Milkshake.Network;
using Milkshake.Tools;
using System.Security.Cryptography;
using System.IO;
using Milkshake.Tools.Config;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Sessions
{
    public class RealmPacket : Packet
    {
        public RealmPacket(byte[] data)  : base(data)
        { }

        public RealmPacket(AuthServerOpCode opCode) : base(opCode.Parse(), (byte)opCode)
        { }
    }

    public class WorldPacket : Packet
    {
        public WorldPacket(byte[] data)  : base(data)
        { }

        public WorldPacket(AuthServerOpCode opCode)  : base(opCode.Parse(), (byte)opCode)
        { }
    }

    public interface ISession
    {
    }

    public class Session : ISession
    {
        public Session()
        {
        }

        
    }

    public class LoginSession : ISession
    {
        public const int BUFFER_SIZE = 1024;
        public const int TIMEOUT = 1000;

        private int connectionID;
        private Socket connectionSocket;
        private byte[] dataBuffer;

        public string ConnectionRemoteIP { get { return connectionSocket.RemoteEndPoint.ToString(); } }
        public int ConnectionID { get { return connectionID; } }

        public LoginSession(int _connectionID, Socket _connectionSocket)
        {
            connectionID = _connectionID;
            connectionSocket = _connectionSocket;
            dataBuffer = new byte[BUFFER_SIZE];

            connectionSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(dataArrival), null);
        }

        private void dataArrival(IAsyncResult _asyncResult)
        {
            int bytesRecived = 0;

            try { bytesRecived = connectionSocket.EndReceive(_asyncResult); }
            catch (Exception e) { Disconnect(e.Source); }

            if (bytesRecived != 0)
            {
                byte[] data = new byte[bytesRecived];
                Array.Copy(dataBuffer, data, bytesRecived);

                onPacket(data);
                connectionSocket.BeginReceive(dataBuffer, 0, dataBuffer.Length, SocketFlags.None, new AsyncCallback(dataArrival), null);
            }
            else
            {
                Disconnect();
            }
        }

        private void sendData(byte[] send)
        {
            byte[] buffer = new byte[send.Length];
            Buffer.BlockCopy(send, 0, buffer, 0, send.Length);

            try
            {
                Log.Print(LogType.Packet, "Sending [" + send[0].ToString("X2") + "] ");
            }
            catch (Exception e)
            { }

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
        }

        private void sentData(IAsyncResult iAr)
        {
            try { connectionSocket.EndSend(iAr); }
            catch { Disconnect(); }
        }

        private void Disconnect(object _obj = null)
        {
            try
            {
                Log.Print(LogType.Server, ConnectionRemoteIP + " User Disconnected");

                connectionSocket.Close();
                //Server.FreeConnectionID(connectionID);
            }
            catch (Exception socketException)
            {
                Log.Print(LogType.Error, socketException.ToString());
            }
        }
        public static SRP6 Srp6;

        String accountName;
        private void onPacket(byte[] _dataBuffer)
        {
            short opCode = BitConverter.ToInt16(_dataBuffer, 0);
            Log.Print(LogType.Server, ConnectionRemoteIP + " Data Recived - OpCode:" + opCode.ToString("X2") + " " + ((AuthServerOpCode)opCode));

            AuthServerOpCode opcode = (AuthServerOpCode)opCode;

            switch (opcode)
            {
                case AuthServerOpCode.AUTH_LOGON_CHALLENGE:
                    AuthLogonChallenge packet = new AuthLogonChallenge(_dataBuffer);

                    accountName = packet.Name;
                    Account account = DBAccounts.GetAccount(packet.Name);

                    byte[] userBytes = Encoding.UTF8.GetBytes(account.Username.ToUpper());
                    byte[] passBytes = Encoding.UTF8.GetBytes(account.Password.ToUpper());

                    Srp6 = new SRP6(false);
                    Srp6.CalculateX(userBytes, passBytes);

                    Packet outPacket = new RealmPacket(AuthServerOpCode.AUTH_LOGON_CHALLENGE);

                    outPacket.Writer.Write((byte)0x00);
                    outPacket.Writer.Write((byte)0x00);

                    outPacket.Writer.Write((byte)AccountStatus.Ok); // WoW_SUCCES
                    outPacket.Writer.Write(Srp6.B);

                    outPacket.Writer.Write((byte)1);
                    outPacket.Writer.Write(Srp6.g[0]);

                    outPacket.Writer.Write((byte)Srp6.N.Length);
                    outPacket.Writer.Write(Srp6.N);
                    outPacket.Writer.Write(Srp6.salt);
                        
                    outPacket.Writer.WriteNull(17);

                    //outPacket.Writer.Write((byte)0);
                    
                    sendData(outPacket.Data);

                    break;

                case AuthServerOpCode.AUTH_LOGON_PROOF:
                    AuthLogonProof packet1 = new AuthLogonProof(_dataBuffer);
                    Srp6.CalculateU(packet1.A);
                    Srp6.CalculateM2(packet1.M1);
                    CalculateAccountHash();

                    byte[] sessionKey = Srp6.K;

                    DBAccounts.SetSessionKey(accountName, Helper.ByteArrayToHex(sessionKey));

                    Console.WriteLine("Coorect: " + IsCorrectHash(packet1.A, packet1.M1));

                    Packet outPacket2 = new RealmPacket(AuthServerOpCode.AUTH_LOGON_PROOF);

                    outPacket2.Writer.Write((byte)0x01); // Command
                    outPacket2.Writer.Write((byte)AccountStatus.Ok); // Error
                    outPacket2.Writer.Write(Srp6.M2); // 20
                    outPacket2.Writer.WriteNull(4);

                    sendData(outPacket2.Data);
                    break;

                case AuthServerOpCode.REALM_LIST:
                    
                      using (MemoryStream ms = new MemoryStream())
                      {
                          using (BinaryWriter bw = new BinaryWriter(ms))
                          {
                             // bw.Write((byte)0x10); // cmd
                             // bw.Write((Int16)0); // size
                              bw.Write((UInt32)0x0000); // Ender?
                              bw.Write((byte)1); // Realm count

                              bw.Write((UInt32)RealmType.PVP); // Icon
                              bw.Write((byte)0); // Flag

                              WriteCString(bw, INI.GetValue(ConfigValues.WORLD, ConfigValues.NAME));
                              WriteCString(bw, INI.GetValue(ConfigValues.WORLD, ConfigValues.IP) + ":" + INI.GetValue(ConfigValues.WORLD, ConfigValues.PORT));

                              bw.Write((float)INI.GetValue<float>(ConfigValues.WORLD, ConfigValues.POPULATION)); // Pop
                              bw.Write((byte)3); // Chars
                              bw.Write((byte)1); // time
                              bw.Write((byte)0); // time

                             bw.Write((UInt16)0x0002); 
                          }
                          
                          byte[] array = ms.ToArray();
                          byte[] header = new byte[1] { 0x10 };

                          MemoryStream lengthstream = new MemoryStream();
                          BinaryWriter length = new BinaryWriter(lengthstream);
                          length.Write((short)array.Length);

                           
                           byte[] endArray = Concat(Concat(header, lengthstream.ToArray()), array);

                           //ReadRealms(endArray);

                           sendData(endArray);
                      }
                    
                      

                    break;

                default:
                    break;
            }

        }

        public void WriteCString(BinaryWriter bw, string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            bw.Write(data);
        }

        private void ReadRealms(byte[] rawData)
        {
            PacketReader reader = new PacketReader(new MemoryStream(rawData));

            byte cmd = reader.ReadByte(); // cmd
            short packet_Size = reader.ReadInt16();
            UInt32 unsued = reader.ReadUInt32();
            byte realmSize = reader.ReadByte();

            for (int i = 0; i < realmSize; i++)
            {
                UInt32 icon = reader.ReadUInt32();
                byte flag = reader.ReadByte();
                string name = "S";
                string address = "S";
                try
                {
                    name = reader.ReadCString();
                    address = reader.ReadCString();
                }
                catch (Exception EF)
                {
                }

                float pop = reader.ReadSingle();
                byte chars = reader.ReadByte();
                byte time = reader.ReadByte();
                byte end = reader.ReadByte();

                if (name != "S") Console.WriteLine(name + " : " + address + " : " + chars);

            }

        }

        public static byte[] SessionKey;
        public void CalculateAccountHash()
        {
            SHA1 shaM1 = new SHA1CryptoServiceProvider();
            byte[] S = Srp6.S;
            var S1 = new byte[16];
            var S2 = new byte[16];

            for (int t = 0; t < 16; t++)
            {
                S1[t] = S[t * 2];
                S2[t] = S[(t * 2) + 1];
            }

            byte[] hashS1 = shaM1.ComputeHash(S1);
            byte[] hashS2 = shaM1.ComputeHash(S2);
            SessionKey = new byte[hashS1.Length + hashS2.Length];
            for (int t = 0; t < 20; t++)
            {
                SessionKey[t * 2] = hashS1[t];
                SessionKey[(t * 2) + 1] = hashS2[t];
            }

            var opad = new byte[64];
            var ipad = new byte[64];

            //Static 16 byte Key located at 0x0088FB3C
            var key = new byte[] { 56, 167, 131, 21, 248, 146, 37, 48, 113, 152, 103, 177, 140, 4, 226, 170 };

            //Fill 64 bytes of same value
            for (int i = 0; i <= 64 - 1; i++)
            {
                opad[i] = 0x05C;
                ipad[i] = 0x036;
            }

            //XOR Values
            for (int i = 0; i <= 16 - 1; i++)
            {
                opad[i] = (byte)(opad[i] ^ key[i]);
                ipad[i] = (byte)(ipad[i] ^ key[i]);
            }

            byte[] buffer1 = Concat(ipad, SessionKey);
            byte[] buffer2 = shaM1.ComputeHash(buffer1);

            buffer1 = Concat(opad, buffer2);
            SessionKey = shaM1.ComputeHash(buffer1);
        }

        public byte[] Concat(byte[] a, byte[] b)
        {
            var res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
            {
                res[t] = a[t];
            }
            for (int t = 0; t < b.Length; t++)
            {
                res[t + a.Length] = b[t];
            }
            return res;
        }

        private bool IsCorrectHash(byte[] a, byte[] m1)
        {
            SHA1 hash = new SHA1Managed();
            byte[] nHash = hash.ComputeHash(Srp6.N);
            byte[] gHash = hash.ComputeHash(Srp6.g);
            byte[] userHash = hash.ComputeHash(Encoding.UTF8.GetBytes("GRAYPE"));

            var ngHash = new byte[20];
            for (int i = 0; i < 20; i++)
            {
                ngHash[i] = (byte)(nHash[i] ^ gHash[i]);
            }

            // Lots of 'Append'ing
            byte[] appended = Append(Append(Append(ngHash, userHash), Append(Srp6.salt, a)),
                                     Append(Srp6.B, Srp6.K));

            byte[] hashed = hash.ComputeHash(appended);

            for (int i = 0; i < 20; i++)
            {
                if (hashed[i] != m1[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static byte[] Append(byte[] buf1, byte[] buf2)
        {
            var result = new byte[buf1.Length + buf2.Length];
            Buffer.BlockCopy(buf1, 0, result, 0, buf1.Length);
            Buffer.BlockCopy(buf2, 0, result, buf1.Length, buf2.Length);
            return result;
        }

    }

      public enum RealmColor : byte
    {
        Green = 0x0,
        Red = 0x1,
        Offline = 0x2,
    }

    public enum RealmTimeZone : byte
    {
        Development = 1,
        USA = 2,
        Oceanic = 3,
        LatinAmerica = 4,
        Tournament = 5,
        Korea = 6,
        Tournament2 = 7,
        English = 8,
        German = 9,
        French = 10,
        Spanish = 11,
        Russian = 12,
        Tournament3 = 13,
        Taiwan = 14,
        Tournament4 = 15,
        China = 16,
        CN1 = 17,
        CN2 = 18,
        CN3 = 19,
        CN4 = 20,
        CN5 = 21,
        CN6 = 22,
        CN7 = 23,
        CN8 = 24,
        Tournament5 = 25,
        TestServer = 26,
        Tournament6 = 27,
        QAServer = 28,
        CN9 = 29,
        TestServer2 = 30
    }

    public enum RealmStatus : byte
    {
        Good = 0x00,
        Locked = 0x01,
    }

    public enum RealmType : byte
    {
        Normal = 0x00,
        PVP = 0x01,
        RP = 0x06,
        RPPVP = 0x08,
    }
}
