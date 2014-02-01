namespace Vanilla.World.Game.Entity.Tools
{
    using System;

    using Vanilla.World.Game.Entity.Constants;

    public class UpdateField : Attribute
    {
        public byte Enum;
        public bool RequiredOnCreation;
        public int Index;

        public UpdateField(byte updateFieldEnum, bool requiredOnCreation = true, int index = -1)
        {
            this.Enum = updateFieldEnum;
            this.RequiredOnCreation = requiredOnCreation;
            this.Index = index;
        }

        public UpdateField(EObjectFields eObjectFields, bool RequiredOnCreation = true) : this((byte)eObjectFields, RequiredOnCreation) { }

        public UpdateField(EGameObjectFields eGameObjectFields, bool RequiredOnCreation = true) : this((byte)eGameObjectFields, RequiredOnCreation) { }

        public UpdateField(EUnitFields eUnitFields, bool RequiredOnCreation = true, int Index = -1) : this((byte)eUnitFields, RequiredOnCreation, Index) { }
    }
}
