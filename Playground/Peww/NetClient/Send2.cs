namespace Packet_Monitor.NetClient
{
    public class Send2
    {

        public static void Hook()
        {
            // Is there already a code cave?
            if (Globals.SendStorage == 0 || Globals.SendCave == 0)
            {
                Globals.SendStorage = Globals.Magic.AllocateMemory(12);

                // Save ebp for application to read from
                Globals.Magic.Asm.AddLine("mov dword [{0}], 1", Globals.SendStorage + 0x00);
                Globals.Magic.Asm.AddLine("mov dword [{0}], ebp", Globals.SendStorage + 0x04);

                // Wait until application writes 1 to [storage + 8]
                Globals.Magic.Asm.AddLine("@loop:");
                Globals.Magic.Asm.AddLine("cmp dword [{0}], 1", Globals.SendStorage + 0x08);
                Globals.Magic.Asm.AddLine("jne @loop");

                // Reset sending flag
                Globals.Magic.Asm.AddLine("mov dword [{0}], 0", Globals.SendStorage + 0x00);
                Globals.Magic.Asm.AddLine("mov dword [{0}], 0", Globals.SendStorage + 0x08);

                // Jump back to original function
                Globals.Magic.Asm.AddLine("lea ecx, [esi + 00000534h]");
                Globals.Magic.Asm.AddLine("jmp {0}", Offsets.NetClient.Send2 + 0x10);

                Globals.SendCave = Globals.Magic.AllocateMemory(Globals.Magic.Asm.Assemble().Length);

                Globals.Magic.Asm.Inject(Globals.SendCave);
                Globals.Magic.Asm.Clear();
            }


            // Detour function
            Globals.Magic.Asm.AddLine("jmp {0}", Globals.SendCave);
            Globals.Magic.Asm.AddLine("nop");

            Globals.Magic.Asm.Inject(Offsets.NetClient.Send2 + 0x0A);
            Globals.Magic.Asm.Clear();
        }

        public static void Unhook()
        {
            // lea ecx, [esi + 00000534h]
            Globals.Magic.WriteBytes(Offsets.NetClient.Send2 + 0x0A, new byte[] { 0x8D, 0x8E, 0x34, 0x05, 0x00, 0x00 });
        }

        public static byte[] Read()
        {
            if (Globals.Magic.ReadUInt(Globals.SendStorage) == 1)
            {
                uint ebp = Globals.Magic.ReadUInt(Globals.SendStorage + 0x04);
                uint datastore = Globals.Magic.ReadUInt(ebp + 0x08);

                int length = Globals.Magic.ReadInt(datastore + 0x10);
                uint buffer = Globals.Magic.ReadUInt(datastore + 0x04);
                byte[] packet = Globals.Magic.ReadBytes(buffer, length);

                Globals.Magic.WriteUInt(Globals.SendStorage + 0x08, 1);

                return packet;
            }

            return null;
        }

    }
}
