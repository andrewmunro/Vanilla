namespace Vanilla.World.Components.Misc
{
    using System;
    using System.Linq;

    using Vanilla.Core.DBC.Structs;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.World.Models;
    using Vanilla.World.Components.Misc.Constants;
    using Vanilla.World.Components.Misc.Packets.Incoming;
    using Vanilla.World.Components.Misc.Packets.Outgoing;
    using Vanilla.World.Game.Entity.Object.Player;
    using Vanilla.World.Network;

    public class MiscComponent : WorldServerComponent
    {
        public MiscComponent(VanillaWorld vanillaWorld)
            : base(vanillaWorld)
        {
            Router.AddHandler<PCNameQuery>(WorldOpcodes.CMSG_NAME_QUERY, OnNameQueryPacket);
            Router.AddHandler<PCTextEmote>(WorldOpcodes.CMSG_TEXT_EMOTE, OnTextEmotePacket);
            Router.AddHandler<PCEmote>(WorldOpcodes.CMSG_EMOTE, OnEmotePacket);
            Router.AddHandler<PCZoneUpdate>(WorldOpcodes.CMSG_ZONEUPDATE, OnZoneUpdatePacket);
            Router.AddHandler<PCAreaTrigger>(WorldOpcodes.CMSG_AREATRIGGER, OnAreaTriggerPacket);
            Router.AddHandler<PCPing>(WorldOpcodes.CMSG_PING, OnPingPacket);
            Router.AddHandler<PCSetSelection>(WorldOpcodes.CMSG_SET_SELECTION, OnSetSelectionPacket);
        }

        public void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            WorldSession target = Server.Sessions.Find(sesh => sesh.Player.Character.GUID == packet.GUID);

            if (target != null)
            {
                session.SendPacket(new PSNameQueryResponse(target.Player.Character));
            }
        }

        private void OnEmotePacket(WorldSession session, PCEmote packet)
        {
            session.SendPacket(new PSEmote(packet.EmoteID, session.Player.ObjectGUID.RawGUID));
        }

        public void OnTextEmotePacket(WorldSession session, PCTextEmote packet)
        {
            //TODO Get the targetname from the packet.GUID
            String targetName = session.Player.Target != null ? session.Player.Target.Character.Name : null;

            Server.TransmitToAll(new PSTextEmote((int)session.Player.Character.GUID, (int)packet.EmoteID, (int)packet.TextID, targetName));

            EmotesText textEmote = Core.DBC.GetDBC<EmotesText>().SingleOrDefault(e => e.textid == packet.TextID);

            switch ((Emote)textEmote.textid)
            {

                case Emote.EMOTE_STATE_SLEEP:
                case Emote.EMOTE_STATE_SIT:
                case Emote.EMOTE_STATE_KNEEL:
                case Emote.EMOTE_ONESHOT_NONE:
                    break;
                default:
                    Server.Sessions.ForEach(s => s.SendPacket(new PSEmote(textEmote.textid, session.Player.ObjectGUID.RawGUID)));
                    session.SendPacket(new PSEmote(textEmote.textid, session.Player.ObjectGUID.RawGUID));
                    break;
            }
        }

        public void OnZoneUpdatePacket(WorldSession session, PCZoneUpdate packet)
        {
            unsafe
            {
                //var areaName = new string(Core.DBC.GetDBC<AreaTable>().SingleOrDefault(a => a.id == packet.ZoneID).areaName);
                //session.SendMessage("[ZoneUpdate] ID:" + packet.ZoneID + " " + areaName);
            }
        }

        public void OnAreaTriggerPacket(WorldSession session, PCAreaTrigger packet)
        {
            AreatriggerTeleport areaTrigger = Core.WorldDatabase.GetRepository<AreatriggerTeleport>().SingleOrDefault(at => at.ID == packet.TriggerID);

            if (areaTrigger != null)
            {
                session.SendMessage("[AreaTrigger] ID:" + packet.TriggerID + " " + areaTrigger.Name);
                session.Player.Character.Map = areaTrigger.TargetMap;
                session.Player.Character.PositionX = areaTrigger.TargetPositionX;
                session.Player.Character.PositionY = areaTrigger.TargetPositionY;
                session.Player.Character.PositionZ = areaTrigger.TargetPositionZ;
                session.Player.Character.Orientation = areaTrigger.TargetOrientation;
                Core.CharacterDatabase.SaveChanges();

                session.SendPacket(new PSTransferPending(areaTrigger.TargetMap));
                session.SendPacket(new PSNewWorld(areaTrigger.TargetMap, areaTrigger.TargetPositionX, areaTrigger.TargetPositionY, areaTrigger.TargetPositionZ, areaTrigger.TargetOrientation));
            }
            else
            {
                session.SendMessage("[AreaTrigger] ID:" + packet.TriggerID);
            }
        }

        public void OnPingPacket(WorldSession session, PCPing packet)
        {
            session.SendMessage("Ping: " + packet.Ping + " Latancy: " + packet.Latency);

            session.SendPacket(new PSPong(packet.Ping));
        }

        public void OnSetSelectionPacket(WorldSession session, PCSetSelection packet)
        {
            PlayerEntity target = null;

            WorldSession op = Core.Server.Sessions.SingleOrDefault(s => s.Player.ObjectGUID.RawGUID == packet.GUID);
            if (op != null) target = op.Player;

            //if (target == null) target = VanillaWorld.UnitComponent.Entitys.Find(e => e.ObjectGUID != null && e.ObjectGUID.RawGUID == packet.GUID);

            if (target != null)
            {
                session.Player.Target = target;
                session.SendMessage("Target: " + target.Character.Name);
            }
            else
            {
                session.SendMessage("Couldnt find target!");
                session.Player.Target = null;
            }
        }
    }
}
