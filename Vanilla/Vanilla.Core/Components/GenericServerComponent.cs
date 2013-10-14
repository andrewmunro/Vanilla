namespace Vanilla.Core.Components
{
    using Vanilla.Core.Network;

    public class GenericServerComponent<TCore, TServer, TRouter> where TCore : VanillaCore where TServer : Server
    {
        public TCore Core;

        public TServer Server;

        public TRouter Router;

        public GenericServerComponent(TCore core)
        {
            this.Core = core;
        }
    }
}
