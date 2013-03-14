using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Milkshake.Tools.Database.Tables;
using Milkshake.Game.Entitys;

namespace Milkshake.Tools.Database.Helpers
{
    public class DBGameObject
    {
        private static List<GameObject> GameObjectQueryCache;
        public static List<GameObject> GameObjectQuery
        {
            get
            {
                if (GameObjectQueryCache == null) GameObjectQueryCache = DB.World.Table<GameObject>().ToList();

                return GameObjectQueryCache;
            }
        }

        private static List<GameObjectTemplate> GameObjectTemplateQueryCache;
        public static List<GameObjectTemplate> GameObjectTemplateQuery
        {
            get
            {
                if (GameObjectTemplateQueryCache == null) GameObjectTemplateQueryCache = DB.World.Table<GameObjectTemplate>().ToList();

                return GameObjectTemplateQueryCache;
            }
        }

        public static List<GameObject> GetGameObjects(PlayerEntity entity, float Radius)
        {
            return GameObjectQuery.FindAll((go) => entity.Character.MapID == go.Map && Distance(entity, go.X, go.Y, go.Z) < Radius);
        }

        public static float Distance(PlayerEntity player, float X, float Y, float Z)
        {
            float dx = player.X - X;
            float dy = player.Y - Y;
            float dz = player.Z - Z;

            return (float)Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz));
        }

        public static GameObjectTemplate GetGameObjectTemplate(uint Entry)
        {
            return GameObjectTemplateQuery.ToList<GameObjectTemplate>().Find((got) => got.Entry == Entry);
        }
    }
}
