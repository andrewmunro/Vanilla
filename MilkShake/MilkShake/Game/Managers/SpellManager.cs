using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Incoming.World.Spell;
using Milkshake.Communication.Outgoing.World.Spell;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Handlers;
using Milkshake.Net;
using Milkshake.Tools.Database.Helpers;

namespace Milkshake.Game.Managers
{
    class SpellManager
    {
        public static void Boot()
        {
            DataRouter.AddHandler<PCCastSpell>(Opcodes.CMSG_CAST_SPELL, OnCastSpell);
            DataRouter.AddHandler<PCCancelSpell>(Opcodes.CMSG_CANCEL_CAST, OnCancelSpell);
        }

        private static void OnCastSpell(WorldSession session, PCCastSpell packet)
        {
            //https://github.com/mangoszero/server/blob/master/src/game/Spell.cpp#L3254
            throw new NotImplementedException();
        }

        private static void OnCancelSpell(WorldSession session, PCCancelSpell packet)
        {
            throw new NotImplementedException();
        }

        public static void OnLearnSpell(WorldSession session, int spellID)
        {
            session.sendPacket(new PSLearnSpell((uint)spellID));
            DBSpells.AddSpell(session.Character, spellID);
        }
    }
}
