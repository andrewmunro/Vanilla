using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Chat;
using Milkshake.Communication.Incoming.World.Spell;
using Milkshake.Communication.Outgoing.World.Spell;
using Milkshake.Game.Constants.Game;
using Milkshake.Game.Constants.Game.World.Spell;
using Milkshake.Game.Handlers;
using Milkshake.Game.Spells;
using Milkshake.Net;
using Milkshake.Network;
using Milkshake.Tools;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Communication.Outgoing.World.Movement;
using System.Timers;
using Milkshake.Tools.Database;
using Milkshake.Tools.DBC;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools;
using Milkshake.Game.Entitys;
using Milkshake.Tools.Database.Tables;
using Spell = Milkshake.Tools.Chat.Commands.Spell;

namespace Milkshake.Game.Managers
{
    class SpellManager
    {
        public Dictionary<Character, SpellCollection> SpellCollections = new Dictionary<Character, SpellCollection>();

        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCCastSpell>(WorldOpcodes.CMSG_CAST_SPELL, OnCastSpell);
            WorldDataRouter.AddHandler<PCCancelSpell>(WorldOpcodes.CMSG_CANCEL_CAST, OnCancelSpell);
        }

        public static void SendInitialSpells(WorldSession session)
        {
            //TODO Fix spellCollection DBC
            //session.sendPacket(new PSInitialSpells(session.Entity.SpellCollection));
        }

        private static void OnCastSpell(WorldSession session, PCCastSpell packet)
        {
            PrepareSpell(session, packet);

            ObjectEntity target = (session.Entity.Target != null) ? session.Entity.Target : session.Entity;

            //WorldServer.TransmitToAll(new PSSpellGo(session.Entity, target, packet.spellID));
            session.sendPacket(new PSCastFailed(packet.spellID));

            SpellEntry spell = DBC.Spells.GetSpellByID((int)packet.spellID);
            float spellSpeed = spell.speed;
            
            /*
            float distance =  (float)Math.Sqrt((session.Entity.X - session.Entity.Target.X) * (session.Entity.X - session.Entity.Target.X) +
                                               (session.Entity.Y - session.Entity.Target.Y) * (session.Entity.Y - session.Entity.Target.Y) +
                                               (session.Entity.Z - session.Entity.Target.Z) * (session.Entity.Z - session.Entity.Target.Z));

            if (distance < 5) distance = 5;
            
            float dx = session.Entity.X - target.X;
            float dy = session.Entity.Y - target.Y;
            float dz = session.Entity.Z - target.Target.Z;
            float radius = 5;
            float distance = (float)Math.Sqrt((dx * dx) + (dy * dy) + (dz * dz)) - radius;

            //if (distance < 5) distance = 5;
            float timeToHit = (spellSpeed > 0) ? (float)Math.Floor(distance / spellSpeed * 1000f) : 0;

            session.sendMessage("Cast [" + spell.Name + "] Distance: " + distance + " Speed: " + spellSpeed + " Time: " + timeToHit);
            float radians = (float)(Math.Atan2(session.Entity.Y - session.Entity.Target.Y, session.Entity.X - session.Entity.Target.X));
            
            if(spellSpeed > 0)
            {
                DoTimer(timeToHit, (s, e) =>
                {
                    WorldServer.TransmitToAll(new PSMoveKnockBack(target, (float)Math.Cos(radians), (float)Math.Sin(radians), -10, -10));
                });
            }
           

           */
        }

        private static void PrepareSpell(WorldSession session, PCCastSpell packet)
        {
            UnitEntity target = session.Entity.Target ?? session.Entity;
        }

        public static void DoTimer(double interval, ElapsedEventHandler elapseEvent)
        {
            Timer aTimer = new Timer(interval);
            aTimer.Elapsed += new ElapsedEventHandler(elapseEvent);
            aTimer.Elapsed += new ElapsedEventHandler((s, e) => ((Timer)s).Stop());
            aTimer.Start();
        }

        private static void OnCancelSpell(WorldSession session, PCCancelSpell packet)
        {
            //throw new NotImplementedException();
        }

        public static void OnLearnSpell(WorldSession session, int spellID)
        {
            session.Entity.SpellCollection.AddSpell(spellID);
        }
    }
}
