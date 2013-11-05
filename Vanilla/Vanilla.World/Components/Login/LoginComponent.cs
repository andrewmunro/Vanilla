namespace Vanilla.World.Components.Login
{
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.Login.Packets.Incoming;
    using Vanilla.World.Components.Login.Packets.Outgoing;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            this.Router.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, this.OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            Character databaseCharacter = Core.CharacterDatabase.GetRepository<Character>().SingleOrDefault(c => c.GUID == packet.GUID);

            session.Player = Core.EntityManager.AddPlayerEntity(databaseCharacter, session);

            session.SendPacket(new PSLoginVerifyWorld((int)databaseCharacter.Map, databaseCharacter.PositionX, databaseCharacter.PositionY, databaseCharacter.PositionZ, databaseCharacter.Orientation));
            session.SendPacket(new PSAccountDataTimes());
            session.SendPacket(new PSSetRestStart());
            session.SendPacket(new PSBindPointUpdate());
            session.SendPacket(new PSTutorialFlags(session.Account, Core.CharacterDatabase.GetRepository<CharacterTutorial>()));
            session.SendPacket(new PSLoginSetTimeSpeed());
            session.SendPacket(new PSInitWorldStates((uint)databaseCharacter.Zone));

            session.SendPacket(session.Player.PacketBuilder.BuildOwnCharacterPacket());
        }
    }
}
