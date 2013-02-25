using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.Update
{
    public enum HighGuid
    {
        HIGHGUID_ITEM = 0x470,                        // blizz 470
        HIGHGUID_CONTAINER = 0x470,                        // blizz 470
        HIGHGUID_PLAYER = 0x000,                        // blizz 070 (temporary reverted back to 0 high guid
        // in result unknown source visibility player with
        // player problems. please reapply only after its resolve)
        HIGHGUID_GAMEOBJECT = 0xF11,                        // blizz F11/F51
        HIGHGUID_TRANSPORT = 0xF12,                        // blizz F12/F52 (for GAMEOBJECT_TYPE_TRANSPORT)
        HIGHGUID_UNIT = 0xF13,                        // blizz F13/F53
        HIGHGUID_PET = 0xF14,                        // blizz F14/F54
        HIGHGUID_VEHICLE = 0xF15,                        // blizz F15/F55
        HIGHGUID_DYNAMICOBJECT = 0xF10,                        // blizz F10/F50
        HIGHGUID_CORPSE = 0xF50,                        // blizz F10/F50 used second variant to resolve conflict with HIGHGUID_DYNAMICOBJECT
        HIGHGUID_BATTLEGROUND = 0x1F1,                        // blizz 1F1, used for battlegrounds and battlefields
        HIGHGUID_MO_TRANSPORT = 0x1FC,                        // blizz 1FC (for GAMEOBJECT_TYPE_MO_TRANSPORT)
        HIGHGUID_INSTANCE = 0x1F4,                        // blizz 1F4
        HIGHGUID_GROUP = 0x1F5,                        // blizz 1F5
        HIGHGUID_GUILD = 0x1FF7,                       // blizz 1FF7
    }
}
