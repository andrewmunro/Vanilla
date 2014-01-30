namespace Vanilla.World
{
    using System;
    using System.Linq;

    using Vanilla.Core.Components;
    using Vanilla.Core.DBC;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.IO;
    using Vanilla.Core.Logging;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.Login.Models;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Components;
    using Vanilla.World.Components.ActionBar;
    using Vanilla.World.Components.Auth;
    using Vanilla.World.Components.Character;
    using Vanilla.World.Components.Chat;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Components.GameObject;
    using Vanilla.World.Components.Login;
    using Vanilla.World.Components.Logout;
    using Vanilla.World.Components.Misc;
    using Vanilla.World.Components.Movement;
    using Vanilla.World.Components.Spell;
    using Vanilla.World.Game.Entity;
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
            Components.Add(new EntityComponent(this));
            Components.Add(new GameObjectComponent(this));
            Components.Add(new LoginComponent(this));
            Components.Add(new LogoutComponent(this));
            Components.Add(new MiscComponent(this));
            Components.Add(new PlayerMovementComponent(this));
            Components.Add(new SpellComponent(this));

            ChatCommandEngine = new ChatCommandParser();

            Server.Start(portNumber, maxConnections);
        }

        public ChatCommandParser ChatCommandEngine { get; set; }

        public WorldServer Server { get; private set; }

        public DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase { get; private set; }

        public DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get; private set; }

        public DBCLibrary DBC { get; private set; }

        public EntityManager EntityManager { get; private set; }
    }
}
