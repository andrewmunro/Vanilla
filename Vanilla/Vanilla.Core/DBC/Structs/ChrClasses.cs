using System.Runtime.InteropServices;

namespace Vanilla.Core.DBC.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("ChrClasses")]
    public unsafe struct ChrClasses
    {
        [FieldOffset(0)]
        public byte ClassID;

        [FieldOffset(3 * 4)]
        public uint PowerType;

        [FieldOffset(5 * 5)]
        public fixed char Name[8];

        [FieldOffset(15 * 4)]
        public uint Spellfamily;
    };
}
