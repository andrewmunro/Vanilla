using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace VanillaSniffer.Packet
{
    public class PacketReader : BinaryReader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PacketReader"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public PacketReader(Stream input)
            : base(input, Encoding.UTF8)
        { }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="PacketReader"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public PacketReader(byte[] data)
            : base(new MemoryStream(data), Encoding.UTF8)
        { }
 
        /// <summary>
        /// Reads a C style, null terminated, string.
        /// </summary>
        /// <returns></returns>
        public string ReadCString()
        {
            string ret = string.Empty;
 
            char c = ReadChar();
            while (c != '\0')
            {
                ret += c;
                c = ReadChar();
            }
            return ret;
        }
 
        /// <summary>
        /// Reads a pascal string. (The string is prefixed by the length.)
        /// </summary>
        /// <param name="numBytesForLength">The number of bytes containing the length of the string (Usually 1).</param>
        /// <returns></returns>
        public string ReadPascalString(byte numBytesForLength)
        {
            uint readCount;
            switch (numBytesForLength)
            {
                case 1:
                    readCount = ReadByte();
                    break;
                case 2:
                    readCount = ReadUInt16();
                    break;
                case 4:
                    readCount = ReadUInt32();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("numBytesForLength");
            }
            string ret = "";
            for (int i = 0; i < readCount; i++)
            {
                ret += ReadChar();
            }
            return ret;
        }

        /// <summary>
        /// Reads a string in reversed order. (Useful for certain situations. Such as; 23niW where it should be Win32)
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public string ReadStringReversed(int length)
        {
            byte[] str = ReadBytes(length);
            Array.Reverse(str);
            return Encoding.UTF8.GetString(str);
        }
 
        /// <summary>
        /// Reads a specified amount of bytes, in reversed order.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public byte[] ReadBytesReversed(int count)
        {
            byte[] ret = ReadBytes(count);
            Array.Reverse(ret);
            return ret;
        }
 
        /// <summary>
        /// Reads the ip address. This assumes the IPAddress bytes are in sequential order!
        /// If not, you need to handle this yourself.
        /// </summary>
        /// <returns></returns>
        public IPAddress ReadIpAddress()
        {
            return new IPAddress(ReadBytes(4));
        }
 
    }
 
}
