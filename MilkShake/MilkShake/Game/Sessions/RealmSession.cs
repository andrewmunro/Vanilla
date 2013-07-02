using System;
using System.Text;
using System.Net.Sockets;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Auth;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Login;
using Milkshake.Game.Handlers;
using Milkshake.Network;
using Milkshake.Tools;
using System.Security.Cryptography;
using System.IO;
using Milkshake.Tools.Config;
using Milkshake.Tools.Cryptography;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.Extensions;

namespace Milkshake.Game.Sessions
{
    public class LoginSession : Session
    {
        public SRP6 Srp6;
        public String accountName { get; set; };
        public byte[] SessionKey;

        public LoginSession(int _connectionID, Socket _connectionSocket) : base(_connectionID, _connectionSocket)
        {
            
        }

        public override void Disconnect(object _obj = null) 
        {
            base.Disconnect();
            MilkShake.login.FreeConnectionID(connectionID);
        }

        public override void sendPacket(Opcodes opcode, byte[] data)
        {
            BinaryWriter writer = new BinaryWriter(new MemoryStream());
            byte[] header = new byte[1] { (byte)opcode };

            BinaryWriter length = new BinaryWriter(writer);
            length.Write((short)array.Length);

            byte[] endArray = Concat(Concat(header, lengthstream.ToArray()), array);


            writer.Write(header);
            writer.Write(data);

            if (opcode == Opcodes.SMSG_CHAR_ENUM)
            {
                Log.Print(LogType.Debug, Helper.ByteArrayToHex(data));
            }

            Log.Print(LogType.Database, connectionID +  "Server -> Client [" + (Opcodes)opcode + "] [0x" + opcode.ToString("X") + "]");

            sendData(((MemoryStream) writer.BaseStream).ToArray());
        }


        internal override void onPacket(byte[] data)
        {
            short opcode = BitConverter.ToInt16(data, 0);
            Log.Print(LogType.Server, ConnectionRemoteIP + " Data Recived - OpCode:" + opcode.ToString("X2") + " " + ((AuthOpcodes)opcode));

            AuthOpcodes code = (AuthOpcodes)opcode;

            DataRouter.CallHandler(this, code, data);

            switch (opcode)
            {
                case AuthOpcodes.REALM_LIST:
                    
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

                              bw.WriteCString(INI.GetValue(ConfigValues.WORLD, ConfigValues.NAME));
                              bw.WriteCString(INI.GetValue(ConfigValues.WORLD, ConfigValues.IP) + ":" + INI.GetValue(ConfigValues.WORLD, ConfigValues.PORT));

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
            }

        }
    }
}
