namespace Vanilla.World.Network
{
    using System.Linq;

    using Vanilla.Core;
    using Vanilla.Core.Cryptography;
    using Vanilla.Core.Logging;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Incoming.World;
    using Vanilla.World.Communication.Incoming.World.Auth;
    using Vanilla.World.Communication.Outgoing.Auth;
    using Vanilla.World.Communication.Outgoing.World;
    using Vanilla.World.Communication.Outgoing.World.ActionBarButton;
    using Vanilla.World.Communication.Outgoing.World.Player;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game;
    using Vanilla.World.Game.Handlers;
    using Vanilla.World.Game.Managers;

    public class WorldLoginHandler
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
            WorldDataRouter.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, OnPlayerLogin);
        }
        
        private static void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            session.Character = VanillaWorld.CharacterDatabase.Characters.Single(character => character.GUID == packet.GUID);
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
        }
        
        private static void OnAuthSession(WorldSession session, PCAuthSession packet)
        {
            session.Account = VanillaWorld.LoginDatabase.Accounts.Single(acs => acs.Username == packet.Username);
            session.crypt = new VanillaCrypt();
            session.crypt.init(Utils.HexToByteArray(session.Account.SessionKey));
            Log.Print(LogType.Debug, "Started Encryption");
            session.SendPacket(new PSAuthResponse());
        }
        
    }
}
