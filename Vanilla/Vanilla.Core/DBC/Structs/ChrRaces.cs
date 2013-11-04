namespace Vanilla.Core.DBC.Structs
{
    using System.Runtime.InteropServices;

    using Vanilla.Core.Constants.Character;

    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("ChrRaces")]
    public unsafe struct ChrRaces
    {
        [FieldOffset(0)]
        public byte RaceID;

        [FieldOffset(2 * 4)]
        public uint FactionID;

        [FieldOffset(4 * 4)]
        public uint ModelF;

        [FieldOffset(5 * 4)]
        public uint ModelM;

        [FieldOffset(8 * 4)]
        public uint TeamID;

        [FieldOffset(14 * 4)]
        public uint StartingTaxiMask;

        [FieldOffset(16 * 4)]
        public uint CinematicSequence;
    };
}
