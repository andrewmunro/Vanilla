using System.Collections.Generic;
using Vanilla.Core.Network;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;
using Vanilla.Login.Components.Realm.Constants;
using Vanilla.Login.Components.Realm.Packets.Outgoing;
using Vanilla.Login.Network;

namespace Vanilla.Login.Components.Realm
{
    public class RealmComponent : LoginServerComponent
    {
        public RealmComponent(VanillaLogin vanillaLogin) : base(vanillaLogin)
        {
            Router.AddHandler(LoginOpcodes.REALM_LIST, OnRealmList);
        }

        private void OnRealmList(LoginSession session, PacketReader reader)
        {
            List<Realm> realms = new List<Realm>();
            realms.Add(new Realm()
            {
                Category = 0,
                Status = RealmColor.Offline,
                IP = "localhost:90",
                Name = "Lucas' Awesome Server Yo",
                Population = 1,
                Type = RealmType.PVP
            });
            session.SendPacket(new PSRealmList(realms, 2));
        }
    }
}
