using System.Collections.Generic;
using Vanilla.Core.Config;
using Vanilla.Core.Network.Packet;
using Vanilla.Core.Opcodes;
using Vanilla.Login.Components.Realm.Constants;

namespace Vanilla.Login.Components.Realm.Packets.Outgoing
{
    internal sealed class PSRealmList : RealmPacket
    {
        public PSRealmList(List<Realm> realms, byte characterCount) : base(LoginOpcodes.REALM_LIST)
        {
            Write((uint)0x0000); // unk1
            Write((byte)realms.Count);

            foreach (Realm realm in realms)
            {
                Write((uint)realm.Type);
                Write((byte)realm.Status);
                WriteCString(realm.Name);
                WriteCString(realm.IP);
                Write(realm.Population);
                Write(characterCount); // Chars
                Write((byte)0); // RealmCategory  
                Write((byte)0); // Unkown
            }
            
            Write((ushort)0x0002);
        }
    }
}