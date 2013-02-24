using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Milkshake.Communication;
using Milkshake.Communication.Outgoing.World.Logout;
using Milkshake.Game.World.Chat;
using Milkshake.Net;

namespace Milkshake.Game.World.Logout
{
    public class LogoutManager
    {
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
            session.sendPacket(Opcodes.SMSG_LOGOUT_CANCEL_ACK, new byte[] { 0x00 });
        }

        public static void Boot()
        {
            Thread thread = new Thread(update);
            thread.Start();
        }

        public static void update()
        {
            while (true)
            {
                foreach (KeyValuePair<WorldSession, DateTime> entry in logoutQueue.ToArray())
                {
                    if (DateTime.Now.Subtract(entry.Value).Seconds >= 20)
                    {
                        entry.Key.sendPacket(Opcodes.SMSG_LOGOUT_COMPLETE, new byte[] { 0x00 });
                        logoutQueue.Remove(entry.Key);
                    }                   
                }
                Console.WriteLine("Queue: "+logoutQueue.Count);
                Thread.Sleep(1000);
            }
        }

    }
}
