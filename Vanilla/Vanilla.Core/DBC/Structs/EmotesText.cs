namespace Vanilla.Core.DBC.Structs
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("EmotesText")]
    public unsafe struct EmotesText
    {
        [FieldOffset(0 * 4)]
        public int id;

        [FieldOffset(1 * 4)]
        public uint textid; 
    }
}
