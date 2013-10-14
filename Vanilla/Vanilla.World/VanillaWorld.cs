namespace Vanilla.World
{
    using System.ServiceModel;

    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Components;
    using Vanilla.Core.IO;
    using Vanilla.World.Components;
    using Vanilla.World.Components.Auth;
    using Vanilla.World.Components.Zone;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Network;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)] 
    public class VanillaWorld : VanillaComponentBasedCore<WorldServerComponent>, IWorldServer
    {
        public VanillaWorld(int portNumber, int maxConnections)
        {
            WorldDatabase = new DatabaseUnitOfWork<WorldDatabase>();
            CharacterDatabase = new DatabaseUnitOfWork<CharacterDatabase>();

            Server = new WorldServer();

            Components.Add(new ZoneComponent(this));
            Components.Add(new LoginComponent(this));

            Server.Start(portNumber, maxConnections);
        }

        public WorldServer Server { get; private set; }

        public DatabaseUnitOfWork<WorldDatabase> WorldDatabase { get; private set; }

        public DatabaseUnitOfWork<CharacterDatabase> CharacterDatabase { get; private set; }
    }
}
