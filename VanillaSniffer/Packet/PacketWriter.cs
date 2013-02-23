using System;
using System.IO;
using System.Text;

namespace VanillaSniffer.Packet
{
    internal class PacketWriter
    {
        public static byte[] WriteRealm(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    // bw.Write((byte)0x10); // cmd
                    // bw.Write((Int16)0); // size
                    bw.Write((UInt32) 0x0000); // Ender?
                    bw.Write((byte) 1); // Realm count

                    bw.Write((UInt32) 1); // Icon
                    bw.Write((byte) 0); // Flag

                    WriteCString(bw, "Lucas extends noobzilla!");
                    WriteCString(bw, "127.0.0.1:8998");

                    bw.Write((float) 1); // Pop
                    bw.Write((byte) 3); // Chars
                    bw.Write((byte) 1); // time
                    bw.Write((byte) 0); // time

                    bw.Write((UInt16) 0x0002);
                }

                byte[] array = ms.ToArray();
                byte[] header = new byte[1] {0x10};

                MemoryStream lengthstream = new MemoryStream();
                BinaryWriter length = new BinaryWriter(lengthstream);
                length.Write((short) array.Length);


                return data = Concat(Concat(header, lengthstream.ToArray()), array);
            }
        }

        public static void WriteCString(BinaryWriter bw, string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            bw.Write(data);
        }

        public static byte[] Concat(byte[] a, byte[] b)
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
    }
}