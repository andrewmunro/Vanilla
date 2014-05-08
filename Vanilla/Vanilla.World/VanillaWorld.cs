using Vanilla.Character.Database;
using Vanilla.Core.Tools;
using Vanilla.World.Components.Weather;
using Vanilla.World.Database;

namespace Vanilla.World
{
    using Vanilla.Core.Components;
    using Vanilla.Core.DBC;
    using Vanilla.Core.IO;
    using Vanilla.World.Components;
    using Vanilla.World.Components.ActionBar;
    using Vanilla.World.Components.Auth;
    using Vanilla.World.Components.Character;
    using Vanilla.World.Components.Chat;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Components.GameObject;
    using Vanilla.World.Components.Login;
    using Vanilla.World.Components.Logout;
    using Vanilla.World.Components.Mail;
    using Vanilla.World.Components.Misc;
    using Vanilla.World.Components.Movement;
    using Vanilla.World.Components.Spell;
    using Vanilla.World.Network;
    using Vanilla.World.Tools.Chat;

    public class VanillaWorld : VanillaComponentBasedCore<WorldServerComponent>, IWorldServer
    {
        public VanillaWorld(int portNumber, int maxConnections)
        {
            DBC = new DBCLibrary();

            WorldDatabase = new DatabaseUnitOfWork<WorldDatabase>();
            CharacterDatabase = new DatabaseUnitOfWork<CharacterDatabase>();

            Server = new WorldServer(this);

            Components.Add(new ActionButtonComponent(this));
            Components.Add(new AuthComponent(this));
            Components.Add(new CharacterComponent(this));
            Components.Add(new ChatMessageComponent(this));
            Components.Add(new WeatherComponent(this));
            Components.Add(new EntityComponent(this));
            Components.Add(new GameObjectComponent(this));
            Components.Add(new LoginComponent(this));
            Components.Add(new LogoutComponent(this));
            Components.Add(new MailComponent(this));
            Components.Add(new MiscComponent(this));
            Components.Add(new PlayerMovementComponent(this));
            Components.Add(new SpellComponent(this));

            ChatCommands = new ChatCommandParser();

            Server.Start(portNumber, maxConnections);

            var accountCreator = new AccountCreator();
            accountCreator.CreateAccount("andrew1", "password");
            accountCreator.CreateAccount("lucas", "password");
        }

        public ChatCommandParser ChatCommands { get; set; }

        public WorldServer Server { get; private set; }

        public DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase { get; private set; }

        public DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get; private set; }

        public DBCLibrary DBC { get; private set; }
    }
}
