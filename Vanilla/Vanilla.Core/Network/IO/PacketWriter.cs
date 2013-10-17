using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip.Compression;
using Vanilla.Core.Constants;

namespace Vanilla.Core.Network.IO
{
    public class PacketWriter : BinaryWriter
    {
        public PacketHeaderType HeaderType { get { return _headerType;} }
        public short Opcode;

        private readonly PacketHeaderType _headerType;
        //private PacketHeaderType header;

        public PacketWriter(short opcode, PacketHeaderType headerType) : this(headerType, new MemoryStream())
        {
            Opcode = opcode;
        }


        public PacketWriter(PacketHeaderType headerType) : this(headerType, new MemoryStream())
        {

        }

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

        // For over ride
        public virtual void WriteHeader(BinaryWriter writer)
        {
            WritePacketHeader(writer, Opcode);
        }

        public virtual string ParseOpcode()
        {
            throw new Exception("Needs override");
        }

        public void WritePacketHeader(BinaryWriter packet, short opcode)
        {
            // Awesomely lazy!
            var length = (ushort)(BaseStream.Length); // -2
            WritePacketHeader(packet, opcode, length);
        }

        public void WritePacketHeader(BinaryWriter packet, short opcode, ushort length)
        {
            switch (_headerType)
            {
                case PacketHeaderType.AuthCmsg:
                    packet.Write((byte)opcode);
                    break;

                case PacketHeaderType.AuthSmsg:
                    packet.Write((byte)opcode);
                    break;

                case PacketHeaderType.RealmSmsg:
                    packet.Write((byte)opcode);
                    packet.Write((ushort)length);
                    break;

                case PacketHeaderType.WorldCmsg:
                    packet.Write(opcode);
                    packet.Write(length);
                    packet.Write((ushort)0);
                    break;

                case PacketHeaderType.WorldSmsg:
                    packet.Write(opcode);
                    packet.Write(length);
                    break;
            }
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
