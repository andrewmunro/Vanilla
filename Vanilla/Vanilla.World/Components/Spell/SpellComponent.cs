namespace Vanilla.World.Components.Spell
{
    using System.Timers;
    using System.Linq;
    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Spell.Packets.Incoming;
    using Vanilla.World.Components.Spell.Packets.Outgoing;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Network;

    public class SpellComponent : WorldServerComponent
    {
        public SpellComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            Router.AddHandler<PCCastSpell>(WorldOpcodes.CMSG_CAST_SPELL, OnCastSpell);
            Router.AddHandler<PCCancelSpell>(WorldOpcodes.CMSG_CANCEL_CAST, OnCancelSpell);
        }

        public void SendInitialSpells(WorldSession session)
        {
            session.SendPacket(new PSInitialSpells(session.Player.SpellCollection));
        }

        private void OnCastSpell(WorldSession session, PCCastSpell packet)
        {

            IUnitEntity target = session.Player.Target ?? session.Player;

            target.SubscribedBy.ToList().ForEach(s => s.SendPacket(new PSSpellGo(session.Player, target, packet.spellID)));
            session.SendPacket(new PSSpellGo(session.Player, target, packet.spellID));
            session.SendPacket(new PSCastFailed(packet.spellID));

            SpellEntry spell = Core.DBC.GetDBC<SpellEntry>().SingleOrDefault(s => s.ID == packet.spellID);
            float spellSpeed = spell.Speed;
            
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

        public void DoTimer(double interval, ElapsedEventHandler elapseEvent)
        {
            Timer aTimer = new Timer(interval);
            aTimer.Elapsed += new ElapsedEventHandler(elapseEvent);
            aTimer.Elapsed += new ElapsedEventHandler((s, e) => ((Timer)s).Stop());
            aTimer.Start();
        }

        private void OnCancelSpell(WorldSession session, PCCancelSpell packet)
        {
            //throw new NotImplementedException();
        }

        public void OnLearnSpell(WorldSession session, int spellID)
        {
            session.Player.SpellCollection.AddSpell(spellID);
        }
    }
}
