using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Core.DBC.Structs
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    [DBCFileAttribute("AreaTable")]
    public unsafe struct AreaTable
    {
        [FieldOffset(0 * 4)]
        public int id;

        [FieldOffset(1 * 4)]
        public int mapID;

        [FieldOffset(2 * 4)]
        public int zone;

        [FieldOffset(11 * 5)]
        public fixed char areaName[8];
    }
}
