using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Entitys
{
    // Make static creators remove GameObject/GameObjectTemplate from variables
    // Eg: GoEntity.CreateFromTemplate(goTemplate);
    //
    public class GOEntity : ObjectEntity
    {
        public override TypeID TypeID { get { return TypeID.TYPEID_GAMEOBJECT; } }
        public override int DataLength { get { return (int)EGameObjectFields.GAMEOBJECT_END; } }

        public GameObject GameObject { get; private set; }
        public GameObjectTemplate GameObjectTemplate { get; private set; }

        public GOEntity(GameObject gameObject, GameObjectTemplate template) : base(ObjectGUID.GetGameObjectGUID())
        {
            GameObject = gameObject;
            GameObjectTemplate = template;

            Entry       = (byte)template.Entry;
            Scale       = GameObjectTemplate.Size;
            DisplayID   = GameObjectTemplate.DisplayID;
            Flags       = template.Flag;
            GOTypeID    = template.Type;
            X           = gameObject.X;
            Y           = gameObject.Y;
            Z           = gameObject.Z;

            // [Placeholder]
            Data = 532676608;
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
