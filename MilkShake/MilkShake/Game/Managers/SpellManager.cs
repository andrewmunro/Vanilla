using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Outgoing.World.Spell;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Handlers;
using Milkshake.Net;

namespace Milkshake.Game.Managers
{
    class SpellManager
    {
        public static void Boot()
        {
            
        }

        public static void OnLearnSpell(WorldSession session, int spellID)
        {
            session.sendPacket(new PSLearnSpell((uint)spellID));
        }
    }
}
