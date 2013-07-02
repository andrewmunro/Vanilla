﻿using System;
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

namespace Milkshake.Game.Managers
{
    class SpellManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCCastSpell>(Opcodes.CMSG_CAST_SPELL, OnCastSpell);
            WorldDataRouter.AddHandler<PCCancelSpell>(Opcodes.CMSG_CANCEL_CAST, OnCancelSpell);
        }

        public static void SendInitialSpells(WorldSession session)
        {
            session.sendPacket(new PSInitialSpells(session.Character));
        }

        private static void OnCastSpell(WorldSession session, PCCastSpell packet)
        {
            PrepareSpell(session, packet);

            //WorldServer.TransmitToAll(new PSSpellGo(session.Entity, target, packet.spellID));
            session.sendPacket(new PSCastFailed(packet.spellID));

            SpellEntry spell = DBC.Spells.GetSpellByID((int)packet.spellID);
            float spellSpeed = spell.Speed;
            
            /*
            float distance =  (float)Math.Sqrt((session.Entity.X - session.Entity.Target.X) * (session.Entity.X - session.Entity.Target.X) +
                                               (session.Entity.Y - session.Entity.Target.Y) * (session.Entity.Y - session.Entity.Target.Y) +
                                               (session.Entity.Z - session.Entity.Target.Z) * (session.Entity.Z - session.Entity.Target.Z));

            if (distance < 5) distance = 5;
            */
            float dx = session.Entity.X - session.Entity.Target.X;
            float dy = session.Entity.Y - session.Entity.Target.Y;
            float dz = session.Entity.Z - session.Entity.Target.Z;
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
                    WorldServer.TransmitToAll(new PSMoveKnockBack(session.Entity.Target, (float)Math.Cos(radians), (float)Math.Sin(radians), -10, -10));
                });
            }
           

           
        }

        private static void PrepareSpell(WorldSession session, PCCastSpell packet)
        {
            PlayerEntity target = session.Entity.Target ?? session.Entity;
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
            session.sendPacket(new PSLearnSpell((uint)spellID));
            DBSpells.AddSpell(session.Character, spellID);
        }
    }
}
