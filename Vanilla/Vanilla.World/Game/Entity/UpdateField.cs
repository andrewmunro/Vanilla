namespace Vanilla.World.Game.Entity
{
    using System;

    public class UpdateField : Attribute
    {
        public byte Enum;

        public bool RequiredOnCreation;

        public UpdateField(byte updateFieldEnum, bool requiredOnCreation = true)
        {
            Enum = updateFieldEnum;
            RequiredOnCreation = requiredOnCreation;
        }

        public UpdateField(EObjectFields eObjectFields, bool RequiredOnCreation = true) : this((byte)eObjectFields, RequiredOnCreation) { }

        public UpdateField(EGameObjectFields eGameObjectFields, bool RequiredOnCreation = true) : this((byte)eGameObjectFields, RequiredOnCreation) { }

        public UpdateField(EUnitFields eUnitFields, bool RequiredOnCreation = true) : this((byte)eUnitFields, RequiredOnCreation) { }
    }
}
