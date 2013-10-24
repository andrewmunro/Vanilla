using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.Constants.Character;

namespace Vanilla.Core.DBC.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("ChrClasses")]
    public unsafe struct ChrClasses
    {
        [FieldOffset(0)]
        public ClassID Class;

        [FieldOffset(3 * 4)]
        public uint PowerType;

        [FieldOffset(5 * 5)]
        public fixed char Name[8];

        [FieldOffset(15 * 4)]
        public uint Spellfamily;
    };
}
