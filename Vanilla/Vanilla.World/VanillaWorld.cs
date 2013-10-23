namespace Vanilla.World
{
    using Vanilla.Core.Components;
    using Vanilla.Core.IO;
    using Vanilla.Database.Character.Models;
    using Vanilla.Database.Login.Models;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Components;
    using Vanilla.World.Components.Auth;
    using Vanilla.World.Components.Character;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Network;

    public class VanillaWorld : VanillaComponentBasedCore<WorldServerComponent>, IWorldServer
    {
        public VanillaWorld(int portNumber, int maxConnections)
        {
            WorldDatabase = new DatabaseUnitOfWork<WorldDatabase>();
            CharacterDatabase = new DatabaseUnitOfWork<CharacterDatabase>();
            LoginDatabase = new DatabaseUnitOfWork<LoginDatabase>();

            Server = new WorldServer();

            Components.Add(new LoginComponent(this));
            Components.Add(new CharacterComponent(this));

            new Entity();
            
            Server.Start(portNumber, maxConnections);
        }

        public WorldServer Server { get; private set; }

        public DatabaseUnitOfWork<LoginDatabase> LoginDatabase { get; private set; }

        public DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase { get; private set; }

        public DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get; private set; }
        
    }
}
