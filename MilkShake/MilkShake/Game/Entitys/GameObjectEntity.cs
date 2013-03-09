using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Tools.Database.Tables;
using Microsoft.Xna.Framework;

namespace Milkshake.Game.Entitys
{
    public class GameObjectEntity : WorldEntity
    {
        private float DegreeToRadian(float angle)
        {
            return (float)Math.PI * angle / 180.0f;
        }

        private float RadianToDegree(float angle)
        {
            return angle * (180.0f / (float)Math.PI);
        }

        public GameObjectEntity(GameObject gameObject, GameObjectTemplate template) : base((int)EGameObjectFields.GAMEOBJECT_END)
        {
            GUID = ObjectGUID.GetGameObjectGUID();

            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_GUID, (uint)GUID.Low);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_DATA, (uint)532676608); // ?
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_TYPE, (uint)TypeID.TYPEID_GAMEOBJECT);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_ENTRY, (uint)template.Entry);
            

            SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)1);
            
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_TYPE_ID, (uint)template.Type);
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, (uint)template.DisplayID);

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_X, (float)gameObject.X);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Y, (float)gameObject.Y);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_POS_Z, (float)gameObject.Z);


            Quaternion pew = Quaternion.CreateFromYawPitchRoll(0, 0, gameObject.R);

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 0, (float)pew.X);     // up down?       
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 1, (float)pew.Y);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 2, (float)pew.Z);
            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_ROTATION + 3, (float)pew.W);
            

            //SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_FACING, 0);           
            

            
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_FLAGS, (uint)40);
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_STATE, (uint)1);
            
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_ANIMPROGRESS, (uint)100);
        }
    }  
}
