namespace Vanilla.World.Components.Logout
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Vanilla.Core.Network.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Components.Logout.Packets.Outgoing;
    using Vanilla.World.Network;

    public class LogoutComponent : WorldServerComponent
    {
        public const int LogoutTime = 1;

        public static Dictionary<WorldSession, DateTime> LogoutQueue;

        public LogoutComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            LogoutQueue = new Dictionary<WorldSession, DateTime>();

            var thread = new Thread(Update);
            thread.Start();

            Router.AddHandler<PacketReader>(WorldOpcodes.CMSG_LOGOUT_REQUEST, OnLogout);
            Router.AddHandler<PacketReader>(WorldOpcodes.CMSG_LOGOUT_CANCEL, OnCancel);
        }

        public static void OnLogout(WorldSession session, PacketReader reader)
        {
            if (LogoutQueue.ContainsKey(session)) LogoutQueue.Remove(session);

            session.SendPacket(new PSLogoutResponse());
            LogoutQueue.Add(session, DateTime.Now);
        }

        public static void OnCancel(WorldSession session, PacketReader reader)
        {
            LogoutQueue.Remove(session);
            session.SendPacket(new PSLogoutCancelAcknowledgement());
        }

        public void Update()
        {
            while (true)
            {
                foreach (KeyValuePair<WorldSession, DateTime> entry in LogoutQueue.ToArray())
                {
                    if (DateTime.Now.Subtract(entry.Value).Seconds >= LogoutTime)
                    {
                        entry.Key.SendPacket(new PSLogoutComplete());
                        LogoutQueue.Remove(entry.Key);
                        Core.GetComponent<EntityComponent>().RemovePlayerEntity(entry.Key.Player);
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
