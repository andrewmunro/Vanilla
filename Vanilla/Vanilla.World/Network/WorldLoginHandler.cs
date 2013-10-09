namespace Vanilla.World.Network
{
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Incoming.World;
    using Vanilla.World.Communication.Incoming.World.Auth;
    using Vanilla.World.Game.Handlers;

    public class WorldLoginHandler
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCAuthSession>(WorldOpcodes.CMSG_AUTH_SESSION, OnAuthSession);
            WorldDataRouter.AddHandler<PCPlayerLogin>(WorldOpcodes.CMSG_PLAYER_LOGIN, OnPlayerLogin);
            WorldDataRouter.AddHandler(WorldOpcodes.CMSG_UPDATE_ACCOUNT_DATA, onUpdateAccount);
        }
    }
}
