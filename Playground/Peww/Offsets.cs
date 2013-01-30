namespace Packet_Monitor
{
    public class Offsets
    {

        public class NetClient
        {
            public static uint Send2;
            public static uint ProcessMessage;
        }

        public static void Initialize()
        {
            NetClient.Send2 = 0x005379A0;
            NetClient.ProcessMessage = 0x537AA0;

            // Add Wow.exe base address
            uint module = (uint)Globals.Magic.MainModule.BaseAddress;

            NetClient.Send2 += module;
            NetClient.ProcessMessage += module;
        }

    }
}
