namespace Packet_Monitor.NetClient
{
    public class ProcessMessage
    {

        public static void Hook()
        {
            // Is there already a code cave?
            if (Globals.ProcessStorage == 0 || Globals.ProcessCave == 0)
            {
                Globals.ProcessStorage = Globals.Magic.AllocateMemory(12);

                // Save ebp for application to read from
                Globals.Magic.Asm.AddLine("mov dword [{0}], 1", Globals.ProcessStorage + 0x00);
                Globals.Magic.Asm.AddLine("mov dword [{0}], ebp", Globals.ProcessStorage + 0x04);

                // Wait until application writes 1 to [storage + 8]
                Globals.Magic.Asm.AddLine("@loop:");
                Globals.Magic.Asm.AddLine("cmp dword [{0}], 1", Globals.ProcessStorage + 0x08);
                Globals.Magic.Asm.AddLine("jne @loop");

                // Reset sending flag
                Globals.Magic.Asm.AddLine("mov dword [{0}], 0", Globals.ProcessStorage + 0x00);
                Globals.Magic.Asm.AddLine("mov dword [{0}], 0", Globals.ProcessStorage + 0x08);

                // Jump back to original function
                Globals.Magic.Asm.AddLine("lea eax, [ebp - 4]");
                Globals.Magic.Asm.AddLine("jmp {0}", Offsets.NetClient.ProcessMessage + 0x10);

                Globals.ProcessCave = Globals.Magic.AllocateMemory(Globals.Magic.Asm.Assemble().Length);

                Globals.Magic.Asm.Inject(Globals.ProcessCave);
                Globals.Magic.Asm.Clear();
            }


            // Detour function
            Globals.Magic.Asm.AddLine("jmp {0}", Globals.ProcessCave);
            Globals.Magic.Asm.AddLine("nop");

            Globals.Magic.Asm.Inject(Offsets.NetClient.ProcessMessage + 0x0D);
            Globals.Magic.Asm.Clear();
        }

        public static void Unhook()
        {
            // lea ecx, [esi + 00000534h]
            Globals.Magic.WriteBytes(Offsets.NetClient.ProcessMessage + 0x0D, new byte[] { 0x8D, 0x45, 0xFC });
        }

        public static byte[] Read()
        {
            if (Globals.Magic.ReadUInt(Globals.ProcessStorage) == 1)
            {
                uint ebp = Globals.Magic.ReadUInt(Globals.ProcessStorage + 0x04);
                uint datastore = Globals.Magic.ReadUInt(ebp + 0x08);

                int length = Globals.Magic.ReadInt(datastore + 0x10);
                uint buffer = Globals.Magic.ReadUInt(datastore + 0x04);
                byte[] packet = Globals.Magic.ReadBytes(buffer, length);

                Globals.Magic.WriteUInt(Globals.ProcessStorage + 0x08, 1);

                return packet;
            }

            return null;
        }

    }
}
