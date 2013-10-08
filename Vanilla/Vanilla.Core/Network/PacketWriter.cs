using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Vanilla.Core.Network
{
    using ICSharpCode.SharpZipLib.Zip.Compression;

    using Vanilla.Core.Constants;

    public class PacketWriter : BinaryWriter
    {
        private readonly PacketHeaderType _headerType;
        private PacketHeaderType header;

        public PacketWriter(PacketHeaderType headerType) : this(headerType, new MemoryStream())
        { }

        protected PacketWriter(PacketHeaderType headerType, Stream output)
            : base(output, Encoding.UTF8)
        {
            _headerType = headerType;
        }

        public byte[] PacketData
        {
            get
            {
                return (BaseStream as MemoryStream).ToArray();
            }
        }

        public void Write()
        {
            Write((byte)0x0);
        }

        public void WriteNull(uint count)
        {
            for (uint i = 0; i < count; i++)
            {
                Write();
            }
        }

        public void WriteCString(string input)
        {
            byte[] data = Encoding.UTF8.GetBytes(input + '\0');
            Write(data);
        }

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

        public void WritePacketHeader(short opcode)
        {
            // Awesomely lazy!
            var length = (ushort)(BaseStream.Length); // -2
            WritePacketHeader(opcode, length);
        }

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
