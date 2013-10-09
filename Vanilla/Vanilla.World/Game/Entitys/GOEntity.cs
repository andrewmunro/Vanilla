namespace Vanilla.World.Game.Entitys
{
    using System;

    using Vanilla.World.Database.Models;
    using Vanilla.World.Game.Constants.Game.Update;
    using Vanilla.World.Tools.Shared;

    // Make static creators remove GameObject/GameObjectTemplate from variables
    // Eg: GoEntity.CreateFromTemplate(goTemplate);
    public class GOEntity : ObjectEntity
    {
        public override TypeID TypeID
        {
            get
            {
                return TypeID.TYPEID_GAMEOBJECT;
            }
        }

        public override int DataLength
        {
            get
            {
                return (int)EGameObjectFields.GAMEOBJECT_END;
            }
        }

        public GameObject GameObject { get; private set; }

        public GameObjectTemplate GameObjectTemplate { get; private set; }

        public override string Name
        {
            get
            {
                return GameObjectTemplate.Name;
            }
        }

        public GOEntity(GameObject gameObject, GameObjectTemplate template) : base(ObjectGUID.GetGameObjectGUID())
        {
            GameObject = gameObject;
            GameObjectTemplate = template;

            Type = 0x21;
            Entry       = (byte)template.Entry;
            Scale       = (GameObjectTemplate.Size > 100) ? 1 : GameObjectTemplate.Size;
            DisplayID   = GameObjectTemplate.DisplayId;
            Flags       = (int)template.Flags;
            GOTypeID    = template.Type;
            X           = gameObject.PositionX;
            Y           = gameObject.PositionY;
            Z           = gameObject.PositionZ;

            Console.WriteLine("GO: " + template.Name + " " + (GameObjectType)template.Type);

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_FACING, gameObject.Orientation);
            //SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_DYN_FLAGS, template.);
        }

        public int DisplayID
        {
            get { return (int)UpdateData[EGameObjectFields.GAMEOBJECT_DISPLAYID]; }
            set { SetUpdateField<int>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, value); }
        }

        public int Flags
        {
            get { return (int)UpdateData[EGameObjectFields.GAMEOBJECT_FLAGS]; }
            set { SetUpdateField<int>((int)EGameObjectFields.GAMEOBJECT_FLAGS, value); }
        }

        public int GOTypeID
        {
            get { return (int)UpdateData[EGameObjectFields.GAMEOBJECT_TYPE_ID]; }
            set { SetUpdateField<int>((int)EGameObjectFields.GAMEOBJECT_TYPE_ID, value); }
        }

        public float X
        {
            get { return (float)UpdateData[EGameObjectFields.GAMEOBJECT_POS_X]; }
            set { SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_X, value); }
        }

        public float Y
        {
            get { return (float)UpdateData[EGameObjectFields.GAMEOBJECT_POS_Y]; }
            set { SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Y, value); }
        }

        public float Z
        {
            get { return (float)UpdateData[EGameObjectFields.GAMEOBJECT_POS_Z]; }
            set { SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Z, value); }
        }
    }  
}
