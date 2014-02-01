namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using Vanilla.Database.World.Models;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Tools;

    public class GameObjectInfo : ObjectInfo
    {
        public GameObjectInfo (ObjectGUID guid, GameObject gameObject, GameObjectTemplate template) : base(guid)
        {
            DisplayID = template.DisplayId;
            Flags = (int)template.Flags;
            TypeID = template.Type;
            X = gameObject.PositionX;
            Y = gameObject.PositionY;
            Z = gameObject.PositionZ;
            Rotation = gameObject.Orientation;
            State = gameObject.State;
        }

        [UpdateField(EGameObjectFields.GAMEOBJECT_DISPLAYID)]
        public int DisplayID { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_FLAGS)]
        public int Flags { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_TYPE_ID)]
        public int TypeID { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_POS_X)]
        public float X { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_POS_Y)]
        public float Y { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_POS_Z)]
        public float Z { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_ROTATION)]
        public float Rotation { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_STATE)]
        public int State { get; set; }
    }
}
