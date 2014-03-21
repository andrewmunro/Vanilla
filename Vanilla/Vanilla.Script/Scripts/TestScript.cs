/*
using Vanilla.Core.Logging;
using Vanilla.World.Database;
using Vanilla.World.Network;

namespace Vanilla.Script.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Vanilla.Server;
    using Vanilla.World.Components.Entity;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Object.Creature;
    using Vanilla.World.Game.Entity.Object.Player;

    class TestScript : VanillaPlugin
    {
        private creature taurenEntry;
        private creature_template taurenTemplate;
        private PlayerEntity player;
        private Random random;
        private List<CreatureEntity> taurens;
        private bool follow;

        public TestScript()
        {
            //6747
            AddChatCommand("rain", "Rain Taurens from the sky", TestCommand);
            AddChatCommand("follow", "Get taurens to follow you", Follow);

            taurens = new List<CreatureEntity>();
            tauren = Core.WorldDatabase.GetRepository<Creature>().SingleOrDefault(c => c.ID == 6747);
            taurenTemplate = Core.WorldDatabase.GetRepository<CreatureTemplate>().SingleOrDefault(c => c.Entry == 6747);
            random = new Random();
            follow = false;
        }

        private void LetItRain()
        {
            while (true)
            {
                update();
                Thread.Sleep(500);
            }
        }

        private void update()
        {
            Vector2 playerPos = new Vector2() {x = player.Location.X, y = player.Location.Y};
            Vector2 taurenPos = RandomRadiusPoint(playerPos, 5, (float)(random.Next() * (Math.PI * 2)));
            if (!follow)
            {
                taurenEntry.PositionX = taurenPos.x;
                taurenEntry.PositionY = taurenPos.y;
                taurenEntry.PositionZ = player.Location.Z + random.Next(5, 30);

                var tauren = new CreatureEntity(ObjectGUID.GetUnitGUID(), taurenEntry, taurenTemplate);
                Core.GetComponent<EntityComponent>().AddCreatureEntity()
                taurens.Add(tauren);

                player.Session.sendMessage("-----------");
                player.Session.sendMessage("DB: " + tauren.ObjectGUID.RawGUID + " | " + tauren.ObjectGUID.Low + " | " + tauren.ObjectGUID.TypeID + " | " + tauren.ObjectGUID.HighGUID);


                if (taurens.Count > 60)
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
            //player = PlayerManager.Players.Count > 0 ? PlayerManager.Players[0] : null;
            //new Thread(LetItRain).Start();
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
*/
