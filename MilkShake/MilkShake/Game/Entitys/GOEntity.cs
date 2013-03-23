using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Database.Tables;
using Microsoft.Xna.Framework;

namespace Milkshake.Game.Entitys
{
    public class GOEntity : EntityBase
    {
        public static List<GOEntity> GOEntitys = new List<GOEntity>();

        private float DegreeToRadian(float angle)
        {
            return (float)Math.PI * angle / 180.0f;
        }

        private float RadianToDegree(float angle)
        {
            return angle * (180.0f / (float)Math.PI);
        }

        public GameObject GameObject;
        public GameObjectTemplate GameObjectTemplate;



        public int DisplayID
        {
            get { return (int)UpdateData[EGameObjectFields.GAMEOBJECT_DISPLAYID]; }
            set { SetUpdateField<int>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, value); }
        }

        public GOEntity(GameObject gameObject, GameObjectTemplate template) : base((int)EGameObjectFields.GAMEOBJECT_END)
        {
            GameObject = gameObject;
            GameObjectTemplate = template;

            //GUID = ObjectGUID.GetGameObjectGUID((uint)gameObject.GUID);
            GUID = ObjectGUID.GetGameObjectGUID();
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_GUID, (uint)GUID.Low);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_DATA, (uint)532676608); // ?


           
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_ENTRY, (uint)template.Entry);

            float size = GameObjectTemplate.Size;

            // Some DB issue
            Scale = GameObjectTemplate.Size != 114 ? GameObjectTemplate.Size : 1;
            DisplayID = GameObjectTemplate.DisplayID;

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_X, (float)gameObject.X);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Y, (float)gameObject.Y);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Z, (float)gameObject.Z);

            
            Quaternion pew = Quaternion.CreateFromYawPitchRoll(0, 0, gameObject.R);

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 0, (float)pew.X);     // up down?       
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 1, (float)pew.Y);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 2, (float)pew.Z);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 3, (float)pew.W);

            //SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_FACING, 0);           



            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_FLAGS, (uint)template.Flag);
            //SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_STATE, (uint)1);
            
            //SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_ANIMPROGRESS, (uint)100);


            //SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_TYPE, (uint)0x41);
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_TYPE_ID, (uint)template.Type);
            //SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_TYPE, (uint)TypeID.TYPEID_DYNAMICOBJECT);

            GOEntitys.Add(this);
        }
    }  
}
