using Vanilla.World.Database;

namespace Vanilla.World.Game.Entity.Object.GameObject
{
    using System;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Tools;

    public class GameObjectInfo : ObjectInfo
    {
        public GameObjectInfo(ObjectGUID guid, gameobject gameObject, gameobject_template template)
            : base(guid)
        {
            DisplayID = template.displayId;
            Flags = (int)template.flags;
            TypeID = template.type;
            State = gameObject.state;
            X = gameObject.position_x;
            Y = gameObject.position_y;
            Z = gameObject.position_z;
            Rotation0 = gameObject.rotation0;
            Rotation1 = gameObject.rotation1;
            Orientation = gameObject.orientation;

            if (gameObject.rotation2 == 0 && gameObject.rotation3 == 0)
            {
                gameObject.rotation2 = (float)Math.Sin(gameObject.orientation / 2);
                gameObject.rotation3 = (float)Math.Cos(gameObject.orientation / 2);
            }

            Rotation2 = gameObject.rotation2;
            Rotation3 = gameObject.rotation3;

            Type |= (int)TypeMask.TYPEMASK_GAMEOBJECT;
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
