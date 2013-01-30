using System.Diagnostics;
using System.Threading;
using Magic;

namespace Packet_Monitor
{
    public class Globals
    {

        public static Process Process;
        public static BlackMagic Magic = new BlackMagic();

        public static Thread Thread;
        public static uint SendStorage;
        public static uint ProcessStorage;
        public static uint SendCave;
        public static uint ProcessCave;

    }
}
