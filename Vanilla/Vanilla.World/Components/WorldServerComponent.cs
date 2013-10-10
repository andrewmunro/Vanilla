namespace Vanilla.World.Components
{
    using Vanilla.Core.Components;
    using Vanilla.World.Network;

    public class WorldServerComponent : GenericServerComponent<VanillaWorld, WorldServer, WorldRouter>
    {
        public WorldServerComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Server = Core.Server;
            Router = Core.Server.Router;
        }
    }
}
