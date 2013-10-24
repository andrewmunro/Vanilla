using System.Runtime.InteropServices;
using Vanilla.Core.Constants.Character;

namespace Vanilla.Core.DBC.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("CharStartOutfit")]
    public unsafe struct CharStartOutfit
    {
        // m_raceID m_classID m_sexID m_outfitID (UNIT_FIELD_BYTES_0 & 0x00FFFFFF)
        // comparable (0 byte = race, 1 byte = class, 2 byte = gender)
        [FieldOffset(4)]
        public RaceID Race;

        [FieldOffset(5)]
        public ClassID Class;

        [FieldOffset(6)]
        public Gender Gender;

        [FieldOffset(8)]
        public fixed int ItemId[12];

        [FieldOffset(14 * 4)]
        public fixed int ItemDisplayId[12];

        [FieldOffset(26 * 4)]
        public fixed int ItemInventorySlot[12];
    };
}
