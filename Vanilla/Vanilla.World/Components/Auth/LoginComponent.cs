using System;

namespace Vanilla.World.Components.Auth
{
    using Vanilla.Character.Database.Models;
    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Auth.Packets.Incoming;
    using Vanilla.World.Components.Zone;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
            Router.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            /*
            session.Character = Core.CharacterDatabase.GetRepository<Character>().SingleOrDefault(c => c.GUID == packet.GUID);
            Core.Components.GetComponent<ZoneComponent>().AddCharacter(session.Character);

            PSUpdateObject playerEntity = PSUpdateObject.CreateOwnCharacterUpdate(session.Character, out session.Entity);
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

        private void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            /*
            session.Account = VanillaWorld.LoginDatabase.Accounts.Single(acs => acs.Username == packet.Username);
            session.crypt = new VanillaCrypt();
            session.crypt.init(Utils.HexToByteArray(session.Account.SessionKey));
            Log.Print(LogType.Debug, "Started Encryption");
            session.SendPacket(new PSAuthResponse());
             * */
        }
    }
}
