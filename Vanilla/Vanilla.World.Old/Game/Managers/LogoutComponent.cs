using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Vanilla.Core.Network.IO;
using Vanilla.World.Communication.Outgoing.Logout;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.Logout;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Network;
using Vanilla.World.Tools;

namespace Vanilla.World.Game.Managers
{
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    public class LogoutComponent
    {
        public const int LOGOUT_TIME = 1;

        public static Dictionary<WorldSession, DateTime> logoutQueue;

        public static void Boot()
        {
            logoutQueue = new Dictionary<WorldSession, DateTime>();

            Thread thread = new Thread(update);
            thread.Start();

            Log.Print(LogType.Server, "Logout queue initialised");

            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_LOGOUT_REQUEST, OnLogout);
            WorldDataRouter.AddHandler<PacketReader>(WorldOpcodes.CMSG_LOGOUT_CANCEL, OnCancel);
        }

        public static void OnLogout(WorldSession session, PacketReader reader)
        {
            if (logoutQueue.ContainsKey(session)) logoutQueue.Remove(session);

            session.SendPacket(new PSLogoutResponse());
            logoutQueue.Add(session, DateTime.Now);
        }

        public static void OnCancel(WorldSession session, PacketReader reader)
        {
            logoutQueue.Remove(session);
            session.SendPacket(new PSLogoutCancelAcknowledgement());
        }       

        public static void update()
        {
            while (true)
            {
                foreach (KeyValuePair<WorldSession, DateTime> entry in logoutQueue.ToArray())
                {
                    if (DateTime.Now.Subtract(entry.Value).Seconds >= LOGOUT_TIME)
                    {
                        entry.Key.SendPacket(new PSLogoutComplete());
                        logoutQueue.Remove(entry.Key);
                        World.DispatchOnPlayerDespawn(entry.Key.Entity);
                    }                   
                }

                Thread.Sleep(1000);
            }
        }
    }
}
