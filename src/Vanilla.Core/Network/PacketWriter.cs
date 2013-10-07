using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using Milkshake.Game.Constants;

namespace Milkshake.Network
{
    public class PacketWriter : BinaryWriter
    {
        private readonly PacketHeaderType _headerType;

        internal PacketWriter(PacketHeaderType headerType) : this(headerType, new MemoryStream())
        { }

        internal PacketWriter(PacketHeaderType headerType, Stream output)
            : base(output, Encoding.UTF8)
        {
            _headerType = headerType;
        }

        /// <summary>
        /// Gets the packet data of this <see cref="PacketWriter"/>.
        /// </summary>
        /// <value>The packet data.</value>
        public byte[] PacketData
        {
            get
            {
                return (BaseStream as MemoryStream).ToArray();
            }
        }

        /// <summary>
        /// Writes a null byte to the stream.
        /// </summary>
        public void Write()
        {
            Write((byte)0x0);
        }

        /// <summary>
        /// Writes the specified number of null bytes.
        /// </summary>
        /// <param name="count">The count.</param>
        public void WriteNull(uint count)
        {
            for (uint i = 0; i < count; i++)
            {
                Write();
            }
        }

        /// <summary>
        /// Writes a C-style string. (Ends with a null terminator)
        /// </summary>
        /// <param name="input">The input.</param>
        public void WriteCString(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            Write(data);
        }

        /// <summary>
        /// Writes the packet header.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        /// <param name="length">The length.</param>
        public void WritePacketHeader(short opcode, ushort length)
        {
            long curPos = BaseStream.Position;
            BaseStream.Seek(0, SeekOrigin.Begin);
            
            switch (_headerType)
            {
                case PacketHeaderType.AuthCmsg:
                    Write((byte)opcode);
                    break;

                case PacketHeaderType.AuthSmsg:
                    Write((byte)opcode);
                    Write(length);
                    break;

                case PacketHeaderType.WorldCmsg:
                    Write(opcode);
                    Write(length);
                    Write((ushort)0);
                    break;

                case PacketHeaderType.WorldSmsg:
                    Write(opcode);
                    Write(length);
                    break;
            }
            BaseStream.Seek(curPos, SeekOrigin.Begin);
        }

        /// <summary>
        /// Writes the packet header.
        /// </summary>
        /// <param name="opcode">The opcode.</param>
        public void WritePacketHeader(short opcode)
        {
            // Awesomely lazy!
            var length = (ushort)(BaseStream.Length); // -2
            WritePacketHeader(opcode, length);
        }

        /// <summary>
        /// Compresses this instance.
        /// </summary>
        public void Compress()
        {
            var deflater = new Deflater();
            byte[] packet = PacketData;
            deflater.SetInput(packet, 0, packet.Length);
            deflater.Finish();

            var compBuffer = new byte[1024];
            var ret = new List<byte>();

            while (!deflater.IsFinished)
            {
                try
                {
                    deflater.Deflate(compBuffer);
                    ret.AddRange(compBuffer);
                    Array.Clear(compBuffer, 0, compBuffer.Length);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
            deflater.Reset();

            Seek((byte)_headerType, SeekOrigin.Begin);
            // Write the compressed bytes over whatever is there.
            Write(ret.ToArray());
            // Set the stream length to the end of the actual packet data.
            // This makes sure we don't have any 'junk' packets at the end.
            OutStream.SetLength(BaseStream.Position);
        }
    }
}
