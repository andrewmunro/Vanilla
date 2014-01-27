namespace Vanilla.World.Components.Login.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Spell;

    internal sealed class PSInitialSpells : WorldPacket
    {
        public PSInitialSpells(SpellCollection spellCollection)
            : base(WorldOpcodes.SMSG_INITIAL_SPELLS)
        {
            //this.Write(Utils.HexToByteArray("00 28 00 62 1C 00 00 C6 00 00 00 4E 00 00 00 51 00 00 00 CB 00 00 00 76 23 00 00 6B 00 00 00 CC 00 00 00 CB 19 00 00 C4 00 00 00 C5 00 00 00 0A 02 00 00 9C 02 00 00 A0 02 00 00 4E 09 00 00 99 09 00 00 94 54 00 00 AF 09 00 00 B1 09 00 00 93 54 00 00 EA 0B 00 00 25 0D 00 00 B5 14 00 00 59 18 00 00 4D 19 00 00 66 18 00 00 67 18 00 00 4E 19 00 00 21 22 00 00 63 1C 00 00 BB 1C 00 00 C2 20 00 00 74 50 00 00 75 23 00 00 9C 23 00 00 A5 23 00 00 72 50 00 00 73 50 00 00 0B 56 00 00 1A 59 00 00 17 00 47 00 00 00 2F 00 00 00 00 00 00 00 00 00 99 09 00 00 2F 00 00 00 00 00 00 00 00 00 9A 09 00 00 2F 00 00 00 00 00 00 00 00 00 9B 09 00 00 2F 00 00 00 00 00 00 00 00 00 9C 09 00 00 2F 00 00 00 00 00 00 00 00 00 9F 09 00 00 2F 00 00 00 00 00 00 00 00 00 0B 10 00 00 2F 00 00 00 00 00 00 00 00 00 0C 10 00 00 2F 00 00 00 00 00 00 00 00 00 0D 10 00 00 2F 00 00 00 00 00 00 00 00 00 0F 10 00 00 2F 00 00 00 00 00 00 00 00 00 26 10 00 00 2F 00 00 00 00 00 00 00 00 00 27 10 00 00 2F 00 00 00 00 00 00 00 00 00 29 10 00 00 2F 00 00 00 00 00 00 00 00 00 2B 10 00 00 2F 00 00 00 00 00 00 00 00 00 F3 14 00 00 2F 00 00 00 00 00 00 00 00 00 F5 14 00 00 2F 00 00 00 00 00 00 00 00 00 F6 14 00 00 2F 00 00 00 00 00 00 00 00 00 F7 14 00 00 2F 00 00 00 00 00 00 00 00 00 8A 19 00 00 2F 00 00 00 00 00 00 00 00 00 B0 19 00 00 2F 00 00 00 00 00 00 00 00 00 FC 1B 00 00 2F 00 00 00 00 00 00 00 00 00 FD 1B 00 00 2F 00 00 00 00 00 00 00 00 00 C6 1C 00 00 2F 00 00 00 00 00 00 00 00 00"));
        
            Write((byte)0);
            Write((short)spellCollection.Count);

            foreach (var s in spellCollection)
            {
                Write((short)s.SpellID);
                Write((short)0);
            }

            Write((UInt16)spellCollection.Count); // SpellCooldowns count.

            foreach (var s in spellCollection)
            {
                Write((uint)s.SpellID);
                Write((short)0);
                Write((short)s.Catagory);

                if (s.Catagory == 0)
                {
                    Write((uint)s.Cooldown);
                    Write((uint)0);
                }
                else
                {
                    Write((uint)0);
                    Write((uint)s.Cooldown);
                }
            }
        }
    }
}