using Vanilla.Character.Database;
using Vanilla.World.Components.Weather;

namespace Vanilla.World.Components.Login
{
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.ActionBar;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Components.Login.Packets.Incoming;
    using Vanilla.World.Components.Login.Packets.Outgoing;
    using Vanilla.World.Components.Spell;
    using Vanilla.World.Network;

    public class LoginComponent : WorldServerComponent
    {
        public LoginComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            this.Router.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, this.OnPlayerLogin);
        }

        private void OnPlayerLogin(WorldSession session, PCPlayerLogin packet)
        {
            character databaseCharacter = Core.CharacterDatabase.GetRepository<character>().SingleOrDefault(c => c.guid == packet.GUID);

            session.Player = Core.GetComponent<EntityComponent>().AddPlayerEntity(databaseCharacter, session);

            session.SendPacket(new PSLoginVerifyWorld((int)databaseCharacter.map, databaseCharacter.position_x, databaseCharacter.position_y, databaseCharacter.position_z, databaseCharacter.orientation));
            session.SendPacket(new PSAccountDataTimes());
            session.SendPacket(new PSSetRestStart());
            session.SendPacket(new PSBindPointUpdate());
            session.SendPacket(new PSTutorialFlags(session.Account, Core.CharacterDatabase.GetRepository<character_tutorial>()));
            //Send Initial Spells
            Core.GetComponent<SpellComponent>().SendInitialSpells(session);
            //Action bars
            Core.GetComponent<ActionButtonComponent>().SendInitialButtons(session);
            session.SendPacket(new PSInitializeFactions());
            session.SendPacket(new PSLoginSetTimeSpeed());
            session.SendPacket(new PSInitWorldStates((uint)databaseCharacter.zone));

            session.SendPacket(session.Player.PacketBuilder.BuildOwnCharacterPacket());
            Core.GetComponent<WeatherComponent>().SendWeather(session);
        }
    }
}
