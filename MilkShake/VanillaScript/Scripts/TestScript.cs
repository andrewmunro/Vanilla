using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Milkshake;
using Milkshake.Communication.Outgoing.World.Movement;
using Milkshake.Game.Entitys;
using Milkshake.Game.Managers;
using Milkshake.Net;
using Milkshake.Tools;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Tables;
using Milkshake.Tools.DBC;

namespace VanillaScript.Scripts
{
    class TestScript : VanillaPlugin
    {
        private static CreatureEntry taurenEntry;
        private static PlayerEntity player;
        private static Random random;
        private static List<UnitEntity> taurens;
        private static List<CreatureEntry> entryList;
        private static bool follow;
        private static int guidCount = 0;

        public TestScript()
        {
            ChatManager.AddChatCommand("rain", "test", TestCommand);
            ChatManager.AddChatCommand("follow", "test", Follow);

            taurens = new List<UnitEntity>();
            entryList = DB.World.Table<CreatureEntry>().ToList();
            taurenEntry = entryList.First(c => c.id == 6747);
            random = new Random();
            follow = false;
        }

        private static void LetItRain()
        {
            while (true)
            {
                update();
                Thread.Sleep(500);
            }
        }

        private static void update()
        {
            Vector2 playerPos = new Vector2() {x = player.X, y = player.Y};
            Vector2 taurenPos = RandomRadiusPoint(playerPos, 5, (float)(random.Next() * (Math.PI * 2)));
            if (!follow)
            {
                if (guidCount == entryList.Count() - 1) return;
                taurenEntry.guid = entryList[guidCount++].guid;
                taurenEntry.position_x = taurenPos.x;
                taurenEntry.position_y = taurenPos.y;
                taurenEntry.position_z = player.Z + random.Next(5, 30);

                UnitEntity tauren = new UnitEntity(taurenEntry);
                MilkShake.UnitComponent.AddEntityToWorld(tauren);
                taurens.Add(tauren);
                player.Session.sendMessage("-----------");
                player.Session.sendMessage("DB: " + tauren.ObjectGUID.RawGUID + " | " + tauren.ObjectGUID.Low + " | " + tauren.ObjectGUID.TypeID + " | " + tauren.ObjectGUID.HighGUID);
                player.Session.sendMessage("LB: " + new ObjectGUID(tauren.ObjectGUID.Low, tauren.ObjectGUID.TypeID, tauren.ObjectGUID.HighGUID).RawGUID);
                player.Session.sendMessage("LB: " + ObjectGUID.GetUnitGUID().RawGUID);

                if (taurens.Count > 30)
                {
                    MilkShake.UnitComponent.RemoveEntityFromWorld(taurens.First());
                    taurens.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < taurens.Count; i++)
                {
                    float angle = 360 / (i + 1);
                    Vector2 point = RandomRadiusPoint(playerPos, 3, angle);

                    taurens[i].Move(point.x, point.y, player.Z);
                }
            }
        }

        private static Vector2 RandomRadiusPoint(Vector2 point, int radius, float randomAngle)
        {
            float newX = (float)(point.x + (radius*Math.Cos(randomAngle)));
            float newY = (float)(point.y + (radius*Math.Sin(randomAngle)));
            return new Vector2() {x = newX, y = newY};
        }

        private static void TestCommand(WorldSession session, string[] args)
        {
            player = PlayerManager.Players.Count > 0 ? PlayerManager.Players[0] : null;
            new Thread(LetItRain).Start();
        }

        private static void Follow(WorldSession session, string[] args)
        {
            follow = !follow;
        }

        public void Unload()
        {
            Log.Print(LogType.Debug, "Unloading script...");
            ChatManager.RemoveChatCommand("rain");
            ChatManager.RemoveChatCommand("follow");
        }
    }

    struct Vector2
    {
        public float x;
        public float y;
    }
}
