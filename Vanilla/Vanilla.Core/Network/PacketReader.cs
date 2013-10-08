using System;
using System.IO;
using System.Net;
using System.Text;
using Vanilla.Core.Cryptography;

namespace Vanilla.Core.Network
{
    using Vanilla.Core.Constants;

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
        /// Reads the op code from the packet header.
        /// </summary>
        /// <param name="headerType">Type of the header.</param>
        /// <returns></returns>
        public ushort ReadOpCode(PacketHeaderType headerType)
        {
            // So we can go back to where we were.
            long curPos = BaseStream.Position;
            // Go to the beginning, as our opcodes start from there.
            base.BaseStream.Seek(0, SeekOrigin.Begin);
            ushort ret;
            switch (headerType)
            {
                case PacketHeaderType.AuthCmsg:
                case PacketHeaderType.AuthSmsg:
                    ret = ReadByte();
                    break;
                case PacketHeaderType.WorldSmsg:
                case PacketHeaderType.WorldCmsg:
                    BaseStream.Seek(2, SeekOrigin.Begin);
                    ret = ReadUInt16();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("headerType");
            }
            // Go back to wherever we were in the stream and return our value
            BaseStream.Seek(curPos, SeekOrigin.Begin);
            return ret;
        }

        /// <summary>
        /// Reads the length from the packet header. (If a length is required for the specific packet type.)
        /// </summary>
        /// <param name="headerType">Type of the header.</param>
        /// <returns></returns>
        public ushort ReadLength(PacketHeaderType headerType)
        {
            // So we can go back to where we were.
            long curPos = BaseStream.Position;
            ushort ret;
            switch (headerType)
            {
                case PacketHeaderType.AuthCmsg:
                    // No length in this header.
                    return 0;
                case PacketHeaderType.AuthSmsg:
                    BaseStream.Seek(1, SeekOrigin.Begin);
                    ret = ReadUInt16();
                    break;
                case PacketHeaderType.WorldSmsg:
                case PacketHeaderType.WorldCmsg:
                    //First 2 bytes in packet
                    ret = ReadUInt16();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("headerType");
            }
            // Go back to wherever we were in the stream and return our value
            BaseStream.Seek(curPos, SeekOrigin.Begin);
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
        /// Reads a <see cref="BigInteger"/>
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public BigInteger ReadBigInteger(int length)
        {
            byte[] tmp = ReadBytes(length);

            return new BigInteger(tmp);
        }

        /// <summary>
        /// Reads the length of the <see cref="BigInteger"/>
        /// </summary>
        /// <returns></returns>
        public BigInteger ReadBigIntegerLength()
        {
            byte len = ReadByte();
            return len == 0 ? new BigInteger(0) : new BigInteger(len);
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

        /// <summary>
        /// Skips the packet header.
        /// </summary>
        /// <param name="headerType">Type of the header.</param>
        public void SkipPacketHeader(PacketHeaderType headerType)
        {
            // Since the enum corresponds to the packet header length already,
            // we just skip it via the value.
            BaseStream.Seek((byte)headerType, SeekOrigin.Begin);
        }
    }
}