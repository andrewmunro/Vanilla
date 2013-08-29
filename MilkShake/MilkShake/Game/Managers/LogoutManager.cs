using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Milkshake.Communication;
using Milkshake.Communication.Outgoing.Auth;
using Milkshake.Communication.Outgoing.World.Logout;
using Milkshake.Net;
using Milkshake.Tools;
using Milkshake.Game.Handlers;
using Milkshake.Network;

namespace Milkshake.Game.Managers
{
    public class LogoutManager
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

            session.sendPacket(new SCLogoutResponse());
            logoutQueue.Add(session, DateTime.Now);
        }

        public static void OnCancel(WorldSession session, PacketReader reader)
        {
            logoutQueue.Remove(session);
            session.sendPacket(new PSLogoutCancelAcknowledgement());
        }       

        public static void update()
        {
            while (true)
            {
                foreach (KeyValuePair<WorldSession, DateTime> entry in logoutQueue.ToArray())
                {
                    if (DateTime.Now.Subtract(entry.Value).Seconds >= LOGOUT_TIME)
                    {
                        entry.Key.sendPacket(new PSLogoutComplete());
                        logoutQueue.Remove(entry.Key);
                        World.DispatchOnPlayerDespawn(entry.Key.Entity);
                    }                   
                }

                Thread.Sleep(1000);
            }
        }
    }
}
