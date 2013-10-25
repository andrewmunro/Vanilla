using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Constants.Character;

namespace Vanilla.Core.DBC
{
    
    public class DBCReader<T> : BinaryReader where T : struct
    {
        public List<T> Records { get; protected set; }

        public DBCReader(string dbcURL) : this(new FileStream(dbcURL, FileMode.Open)) { }

        public DBCReader(Stream stream) : base(stream)
        {
            Records = new List<T>();

            ReadChars(4); // Magic
            
            uint recordCount = ReadUInt32();
            uint fieldCount = ReadUInt32();
            uint recordSize = ReadUInt32();
            uint stringBlockSize = ReadUInt32();

            for (int i = 0; i < recordCount; i++)
            {
                T parsedStruct = ReadStruct<T>(ReadBytes((int)recordSize));
                Records.Add(parsedStruct);
            }

            char[] pow = ReadChars((int)stringBlockSize);
        }

        public static T ReadStruct<T>(byte[] data) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            T returnObject = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return returnObject;
        }
    }
}
