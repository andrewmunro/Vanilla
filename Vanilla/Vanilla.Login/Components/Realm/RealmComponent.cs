using Vanilla.Core.Network;
using Vanilla.Core.Opcodes;
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
            session.SendPacket(new PSRealmList());
        }
    }
}
