namespace Vanilla.World.Game.Entity
{
    using System;

    public class EnumAttribute : Attribute
    {
        public byte Enum;

        public EnumAttribute(EGameObjectFields eGameObjectFields)
        {
            Enum = (byte)eGameObjectFields;
        }
    }
}
