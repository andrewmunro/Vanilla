using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Update;

namespace Milkshake.Game.Entitys
{
    public class GameObjectEntity : WorldEntity
    {
        public GameObjectEntity(ulong guid, int DISPLA) : base((int)EGameObjectFields.GAMEOBJECT_END)
        {
            uint uintGUID = (uint)(guid & (ulong)0x0000000000FFFFFF);

            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_GUID, (uint)uintGUID);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_DATA, (uint)532676608);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_TYPE, (uint)33);
            SetUpdateField<uint>((int)EObjectFields.OBJECT_FIELD_ENTRY, (uint)175080);
            SetUpdateField<float>((int)EObjectFields.OBJECT_FIELD_SCALE_X, (float)1f);

            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_DISPLAYID, (uint)DISPLA);
            //SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_FLAGS, (uint)40);
            //SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_STATE, (uint)1);
            SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_TYPE_ID, (uint)26);
            //SetUpdateField<uint>((int)EGameObjectFields.GAMEOBJECT_ANIMPROGRESS, (uint)100);
        }
    }  
}
