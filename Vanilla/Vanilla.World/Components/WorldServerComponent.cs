namespace Vanilla.World.Components
{
    using Vanilla.Core.Components;
    using Vanilla.World.Network;

    public abstract class WorldServerComponent : GenericServerComponent<VanillaWorld, WorldServer, WorldRouter>
    {
        protected WorldServerComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Server = Core.Server;
            Router = Core.Server.Router;
        }

        public virtual void Update()
        {
            
        }
    }
}
