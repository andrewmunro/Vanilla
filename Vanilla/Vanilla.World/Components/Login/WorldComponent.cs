using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.IO;
using Vanilla.Core.Logging;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;
using Vanilla.World.Network;

namespace Vanilla.World.Components.World
{
    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler(WorldOpcodes.CMSG_PLAYER_LOGIN, OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PacketReader reader)
        {
            Log.Print("Trying to login");
            
            /*
             * PSUpdateObject playerEntity = PSUpdateObject.CreateOwnCharacterUpdate(session.Character, out session.Entity);
            session.SendPacket(new LoginVerifyWorld((int)session.Character.Map, session.Character.PositionX, session.Character.PositionY, session.Character.PositionZ, 0));
            session.SendPacket(new PSAccountDataTimes());
            session.SendPacket(new PSSetRestStart());
            session.SendPacket(new PSBindPointUpdate());
            session.SendPacket(new PSTutorialFlags(session.Account));
            SpellComponent.SendInitialSpells(session);
            session.SendPacket(new PSActionButtons(session.Character));
            session.SendPacket(new PSInitializeFactions());
            session.SendPacket(new PSLoginSetTimeSpeed());
            session.SendPacket(new PSInitWorldStates());
            session.SendPacket(playerEntity);
            session.Entity.Session = session;
            World.DispatchOnPlayerSpawn(session.Entity);
             * */
        }
    }
}
