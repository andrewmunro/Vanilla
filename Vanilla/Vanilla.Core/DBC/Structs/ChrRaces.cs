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
    [DBCFileAttribute("ChrRaces")]
    public unsafe struct ChrRaces
    {
        [FieldOffset(0)]
        public RaceID Class;

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
