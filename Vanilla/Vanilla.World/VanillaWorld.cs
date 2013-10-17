using Vanilla.Login.Database.Models;
using Vanilla.World.Components.Char;

namespace Vanilla.World
{
    using System.ServiceModel;

    using Database.Character.Models;
    using Vanilla.Core.Components;
    using Vanilla.Core.IO;
    using Vanilla.World.Components;
    using Vanilla.World.Components.Auth;
    using Vanilla.World.Components.Zone;
    using Database.World.Models;
    using Vanilla.World.Network;

    public class VanillaWorld : VanillaComponentBasedCore<WorldServerComponent>, IWorldServer
    {
        public VanillaWorld(int portNumber, int maxConnections)
        {
            WorldDatabase = new DatabaseUnitOfWork<WorldDatabase>();
            CharacterDatabase = new DatabaseUnitOfWork<CharacterDatabase>();
            LoginDatabase = new DatabaseUnitOfWork<LoginDatabase>();

            Server = new WorldServer();

            Components.Add(new ZoneComponent(this));
            Components.Add(new LoginComponent(this));
            Components.Add(new CharacterComponent(this));
            
            Server.Start(portNumber, maxConnections);
        }

        public WorldServer Server { get; private set; }

        public DatabaseUnitOfWork<LoginDatabase> LoginDatabase { get; private set; }
        public DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase { get; private set; }
        public DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get; private set; }
        
    }
}
