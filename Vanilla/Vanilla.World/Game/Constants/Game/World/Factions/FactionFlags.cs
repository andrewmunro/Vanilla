using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.World.Factions
{
    enum FactionFlags
    {
        FACTION_FLAG_VISIBLE = 0x01,                 // makes visible in client (set or can be set at interaction with target of this faction)
        FACTION_FLAG_AT_WAR = 0x02,                 // enable AtWar-button in client. player controlled (except opposition team always war state), Flag only set on initial creation
        FACTION_FLAG_HIDDEN = 0x04,                 // hidden faction from reputation pane in client (player can gain reputation, but this update not sent to client)
        FACTION_FLAG_INVISIBLE_FORCED = 0x08,                 // always overwrite FACTION_FLAG_VISIBLE and hide faction in rep.list, used for hide opposite team factions
        FACTION_FLAG_PEACE_FORCED = 0x10,                 // always overwrite FACTION_FLAG_AT_WAR, used for prevent war with own team factions
        FACTION_FLAG_INACTIVE = 0x20,                 // player controlled, state stored in characters.data ( CMSG_SET_FACTION_INACTIVE )
        FACTION_FLAG_RIVAL = 0x40                  // flag for the two competing outland factions
    }
}
