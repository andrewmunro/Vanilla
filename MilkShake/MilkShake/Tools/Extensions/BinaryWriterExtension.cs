using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Milkshake.Tools.Extensions
{
    public static class BinaryWriterExtension
    {
        public static void WriteCString(this BinaryWriter writer, string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            writer.Write(data);
        }

        public static void WriteBytes(this BinaryWriter writer, byte[] data, int count = 0)
        {
            if (count == 0)
                writer.Write(data);
            else
                writer.Write(data, 0, count);
        }

        public static void WriteBitArray(this BinaryWriter writer, BitArray buffer, int Len)
        {
            byte[] bufferarray = new byte[Convert.ToByte((buffer.Length + 8) / 8) + 1];
            buffer.CopyTo(bufferarray, 0);

            WriteBytes(writer, bufferarray.ToArray(), Len);
        }

        public static void WriteNull(this BinaryWriter writer, uint count)
        {
            for (uint i = 0; i < count; i++)
            {
                writer.Write((byte)0);
            }
        }
    }
}
