namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using System;

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
            State = gameObject.State;
            X = gameObject.PositionX;
            Y = gameObject.PositionY;
            Z = gameObject.PositionZ;
            Rotation0 = gameObject.Rotation0;
            Rotation1 = gameObject.Rotation1;
            Orientation = gameObject.Orientation;

            if (gameObject.Rotation2 == 0 && gameObject.Rotation3 == 0)
            {
                gameObject.Rotation2 = (float)Math.Sin(gameObject.Orientation / 2);
                gameObject.Rotation3 = (float)Math.Cos(gameObject.Orientation / 2);
            }

            Rotation2 = gameObject.Rotation2;
            Rotation3 = gameObject.Rotation3;
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

        [UpdateField(EGameObjectFields.GAMEOBJECT_ROTATION + 0)]
        public float Rotation0 { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_ROTATION + 1)]
        public float Rotation1 { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_ROTATION + 2)]
        public float Rotation2 { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_ROTATION + 3)]
        public float Rotation3 { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_FACING)]
        public float Orientation { get; set; }

        [UpdateField(EGameObjectFields.GAMEOBJECT_STATE)]
        public int State { get; set; }
    }
}
