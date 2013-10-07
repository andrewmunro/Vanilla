using System;
using Vanilla.World.Game.Constants.Game.Update;
using Vanilla.World.Tools.Shared;

namespace Vanilla.World.Game.Entitys
{
    public enum GOType : byte
    {
        GAMEOBJECT_TYPE_DOOR                  = 0,
        GAMEOBJECT_TYPE_BUTTON                = 1,
        GAMEOBJECT_TYPE_QUESTGIVER            = 2,
        GAMEOBJECT_TYPE_CHEST                 = 3,
        GAMEOBJECT_TYPE_BINDER                = 4,
        GAMEOBJECT_TYPE_GENERIC               = 5,
        GAMEOBJECT_TYPE_TRAP                  = 6,
        GAMEOBJECT_TYPE_CHAIR                 = 7,
        GAMEOBJECT_TYPE_SPELL_FOCUS           = 8,
        GAMEOBJECT_TYPE_TEXT                  = 9,
        GAMEOBJECT_TYPE_GOOBER                = 10,
        GAMEOBJECT_TYPE_TRANSPORT             = 11,
        GAMEOBJECT_TYPE_AREADAMAGE            = 12,
        GAMEOBJECT_TYPE_CAMERA                = 13,
        GAMEOBJECT_TYPE_MAPOBJECT             = 14,
        GAMEOBJECT_TYPE_MO_TRANSPORT          = 15,
        GAMEOBJECT_TYPE_DUELFLAG              = 16,
        GAMEOBJECT_TYPE_FISHINGNODE           = 17,
        GAMEOBJECT_TYPE_SUMMONING_RITUAL      = 18,
        GAMEOBJECT_TYPE_MAILBOX               = 19,
        GAMEOBJECT_TYPE_DONOTUSE              = 20,
        GAMEOBJECT_TYPE_GUARDPOST             = 21,
        GAMEOBJECT_TYPE_SPELLCASTER           = 22,
        GAMEOBJECT_TYPE_MEETINGSTONE          = 23,
        GAMEOBJECT_TYPE_FLAGSTAND             = 24,
        GAMEOBJECT_TYPE_FISHINGHOLE           = 25,
        GAMEOBJECT_TYPE_FLAGDROP              = 26,
        GAMEOBJECT_TYPE_MINI_GAME             = 27,
        GAMEOBJECT_TYPE_LOTTERYKIOSK          = 28,
        GAMEOBJECT_TYPE_CAPTURE_POINT         = 29,
        GAMEOBJECT_TYPE_AURA_GENERATOR        = 30,
        GAMEOBJECT_TYPE_DUNGEON_DIFFICULTY    = 31,
        GAMEOBJECT_TYPE_BARBER_CHAIR          = 32,
        GAMEOBJECT_TYPE_DESTRUCTIBLE_BUILDING = 33,
        GAMEOBJECT_TYPE_GUILD_BANK            = 34,
        GAMEOBJECT_TYPE_TRAPDOOR              = 35,
    }
    // Make static creators remove GameObject/GameObjectTemplate from variables
    // Eg: GoEntity.CreateFromTemplate(goTemplate);
    //
    public class GOEntity : ObjectEntity
    {
        public override TypeID TypeID { get { return TypeID.TYPEID_GAMEOBJECT; } }
        public override int DataLength { get { return (int)EGameObjectFields.GAMEOBJECT_END; } }

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
            DisplayID   = GameObjectTemplate.DisplayID;
            Flags       = template.Flag;
            GOTypeID    = template.Type;
            X           = gameObject.X;
            Y           = gameObject.Y;
            Z           = gameObject.Z;

            Console.WriteLine("GO: " + template.Name + " " + (GOType)template.Type);

            SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_FACING, gameObject.R);
            //SetUpdateField<float>((int)EGameObjectFields.GAMEOBJECT_DYN_FLAGS, template.);
            // [Placeholder]
            //Data = 532676608;
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
