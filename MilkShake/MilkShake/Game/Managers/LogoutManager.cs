using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Milkshake.Communication;
using Milkshake.Communication.Outgoing.World.Logout;
using Milkshake.Net;
using Milkshake.Tools;

namespace Milkshake.Game.Managers
{
    public class LogoutManager
    {
        public const int LOGOUT_TIME = 1;

        public static Dictionary<WorldSession, DateTime> logoutQueue = new Dictionary<WorldSession, DateTime>();

        public static void OnLogout(WorldSession session)
        {
            if (logoutQueue.ContainsKey(session)) logoutQueue.Remove(session);

            session.sendPacket(new SCLogoutResponse());
            logoutQueue.Add(session, DateTime.Now);
        }

        public static void OnCancel(WorldSession session)
        {
            logoutQueue.Remove(session);
            session.sendPacket(Opcodes.SMSG_LOGOUT_CANCEL_ACK, 0);
        }

        public static void Boot()
        {
            Thread thread = new Thread(update);
            thread.Start();
            Log.Print(LogType.Server, "Logout queue initialised");
        }

        public static void update()
        {
            while (true)
            {
                foreach (KeyValuePair<WorldSession, DateTime> entry in logoutQueue.ToArray())
                {
                    if (DateTime.Now.Subtract(entry.Value).Seconds >= LOGOUT_TIME)
                    {
                        entry.Key.sendPacket(Opcodes.SMSG_LOGOUT_COMPLETE, 0);
                        logoutQueue.Remove(entry.Key);
                    }                   
                }
                Thread.Sleep(1000);
            }
        }
    }
}
