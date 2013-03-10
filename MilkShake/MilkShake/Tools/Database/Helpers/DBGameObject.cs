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
        private static List<GameObject> GameObjectCache;
        public static List<GameObject> GameObjects
        {
            get
            {
                if (GameObjectQueryCache == null) GameObjectQueryCache = DB.World.Table<GameObject>().ToList();

                return GameObjectCache;
            }
        }

        private static List<GameObjectTemplate> GameObjectTemplateCache;
        public static List<GameObjectTemplate> GameObjectTemplates
        {
            get
            {
                if (GameObjectTemplateQueryCache == null) GameObjectTemplateQueryCache = DB.World.Table<GameObjectTemplate>().ToList();

                return GameObjectTemplateCache;
            }
        }

        public static List<GameObject> GetGameObjects(PlayerEntity entity, float Radius)
        {
            return GameObjects.FindAll((go) => entity.Character.MapID == go.Map && Distance(entity, go.X, go.Y, go.Z) < Radius);
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
            return GameObjectTemplates.ToList<GameObjectTemplate>().Find((got) => got.Entry == Entry);
        }
    }
}
