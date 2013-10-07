using System.Collections.Generic;
using System.Linq;
using Vanilla.World.Game.Entitys;

namespace Vanilla.World.Tools.Database.Helpers
{
    public class DBGameObject
    {
        private static List<GameObject> GameObjectCache;
        public static List<GameObject> GameObjects
        {
            get
            {
                if (GameObjectCache == null) GameObjectCache = DB.World.Table<GameObject>().ToList();

                return GameObjectCache;
            }
        }

        private static List<GameObjectTemplate> GameObjectTemplateCache;
        public static List<GameObjectTemplate> GameObjectTemplates
        {
            get
            {
                if (GameObjectTemplateCache == null) GameObjectTemplateCache = DB.World.Table<GameObjectTemplate>().ToList();

                return GameObjectTemplateCache;
            }
        }

        public static List<GameObject> GetGameObjects(PlayerEntity entity, float Radius)
        {
            return GameObjects.FindAll((go) => go.Map == entity.Character.MapID && Helper.Distance(entity.Character.X, entity.Character.Y, go.X, go.Y) < Radius);
        }

        public static GameObjectTemplate GetGameObjectTemplate(uint Entry)
        {
            return GameObjectTemplates.ToList<GameObjectTemplate>().Find((got) => got.Entry == Entry);
        }
    }
}
