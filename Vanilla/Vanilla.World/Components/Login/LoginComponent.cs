namespace Vanilla.World.Components.Login
{
    using Vanilla.Core.Logging;
    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.Login.Packets.Incoming;
    using Vanilla.World.Game.Entity.Character;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            this.Router.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, this.OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            Log.Print("Trying to login");

            Character databaseCharacter = Core.CharacterDatabase.GetRepository<Character>().SingleOrDefault(c => c.GUID == packet.GUID);

            session.Character = new CharacterEntity(databaseCharacter);
            //session.UpdatePacketBuilder;

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
