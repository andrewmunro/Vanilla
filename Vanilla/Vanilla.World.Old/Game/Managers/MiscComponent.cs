using System;
using Vanilla.World.Communication.Incoming.World.GameObject;
using Vanilla.World.Communication.Incoming.World.Player;
using Vanilla.World.Communication.Outgoing.Players;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.Player;
using Vanilla.World.Game.Constants.Game.World.Entity;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Tools.DBC;
using Vanilla.World.Tools.DBC.Tables;

namespace Vanilla.World.Game.Managers
{
    using Vanilla.Core.Opcodes;
    using Database.World.Models;
    using Vanilla.World.Network;

    public class MiscComponent
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCNameQuery>(WorldOpcodes.CMSG_NAME_QUERY, OnNameQueryPacket);
            WorldDataRouter.AddHandler<PCTextEmote>(WorldOpcodes.CMSG_TEXT_EMOTE, OnTextEmotePacket);
            WorldDataRouter.AddHandler<PCEmote>(WorldOpcodes.CMSG_EMOTE, OnEmotePacket);
            WorldDataRouter.AddHandler<PCZoneUpdate>(WorldOpcodes.CMSG_ZONEUPDATE, OnZoneUpdatePacket);
            WorldDataRouter.AddHandler<PCAreaTrigger>(WorldOpcodes.CMSG_AREATRIGGER, OnAreaTriggerPacket);
            WorldDataRouter.AddHandler<PCPing>(WorldOpcodes.CMSG_PING, OnPingPacket);
            WorldDataRouter.AddHandler<PCSetSelection>(WorldOpcodes.CMSG_SET_SELECTION, OnSetSelectionPacket);
            WorldDataRouter.AddHandler<PCGameObjectQuery>(WorldOpcodes.CMSG_GAMEOBJECT_QUERY, OnGameObjectQuery);
        }

        public static void OnNameQueryPacket(WorldSession session, PCNameQuery packet)
        {
            Character target = DBCharacters.Characters.Find(character => character.GUID == packet.GUID);

            if (target != null)
            {
                session.SendPacket(new PSNameQueryResponse(target));
            }
        }

        public static void OnGameObjectQuery(WorldSession session, PCGameObjectQuery packet)
        {            
            GameObjectTemplate template = DBGameObject.GameObjectTemplates.Find(g => g.Entry == packet.EntryID);
            //session.SendPacket(new PSGameObjectQueryResponse(template));
            //session.sendMessage("Requested Info: " + template.Name + " " + (GameobjectTypes)template.Type);
        }

        private static void OnEmotePacket(WorldSession session, PCEmote packet)
        {
            session.SendPacket(new PSEmote(packet.EmoteID, session.Entity.ObjectGUID.RawGUID));
        }

        public static void OnTextEmotePacket(WorldSession session, PCTextEmote packet)
        {
            //TODO Get the targetname from the packet.GUID
            String targetName = session.Entity.Target != null ? session.Entity.Target.Name : null;

            WorldServer.TransmitToAll(new PSTextEmote((int)session.Character.GUID, (int)packet.EmoteID, (int)packet.TextID, targetName));
            
            EmotesTextEntry textEmote = DBC.EmotesText.List.Find(e => e.ID == packet.TextID);

            switch ((Emote)textEmote.TextID)
            {
                    
                case Emote.EMOTE_STATE_SLEEP:
                case Emote.EMOTE_STATE_SIT:
                case Emote.EMOTE_STATE_KNEEL:
                case Emote.EMOTE_ONESHOT_NONE:
                    break;
                default:
                    World.SessionsWhoKnow(session.Entity).ForEach(s => s.SendPacket(new PSEmote(textEmote.TextID, session.Entity.ObjectGUID.RawGUID)));
                    session.SendPacket(new PSEmote(textEmote.TextID, session.Entity.ObjectGUID.RawGUID));
                    break;
            }
        }

        public static void OnZoneUpdatePacket(WorldSession session, PCZoneUpdate packet)
        {
            session.sendMessage("[ZoneUpdate] ID:" + packet.ZoneID + " " + DBC.AreaTables.Find(a => a.ID == packet.ZoneID).Name);
        }

        public static void OnAreaTriggerPacket(WorldSession session, PCAreaTrigger packet)
        {
            AreatriggerTeleport areaTrigger = DBAreaTriggers.AreaTriggerTeleport.Find(at => at.ID == packet.TriggerID);

            if (areaTrigger != null)
            {
                session.sendMessage("[AreaTrigger] ID:" + packet.TriggerID + " " + areaTrigger.Name);
                session.Character.MapID = areaTrigger.TargetMap;
                session.Character.X = areaTrigger.TargetX;
                session.Character.Y = areaTrigger.TargetY;
                session.Character.Z = areaTrigger.TargetZ;
                session.Character.Rotation = areaTrigger.TargetR;
                DBCharacters.UpdateCharacter(session.Character);

                session.SendPacket(new PSTransferPending(areaTrigger.TargetMap));
                session.SendPacket(new PSNewWorld(areaTrigger.TargetMap, areaTrigger.TargetX, areaTrigger.TargetY, areaTrigger.TargetZ, areaTrigger.TargetR));
                
            }
            else
            {
                session.sendMessage("[AreaTrigger] ID:" + packet.TriggerID);
            }
        }

        public static void OnPingPacket(WorldSession session, PCPing packet)
        {
            session.sendMessage("Ping: " + packet.Ping + " Latancy: " + packet.Latency);

            session.SendPacket(new PSPong(packet.Ping));
        }

        public static void OnSetSelectionPacket(WorldSession session, PCSetSelection packet)
        {
            UnitEntity target = null;

            WorldSession op = WorldServer.Sessions.Find(s => s.Entity.ObjectGUID.RawGUID == packet.GUID);
            if(op != null) target = op.Entity;

            if (target == null) target = VanillaWorld.UnitComponent.Entitys.Find(e => e.ObjectGUID != null && e.ObjectGUID.RawGUID == packet.GUID);

            if (target != null)
            {
                session.Entity.Target = target;
                session.sendMessage("Target: " + target.Name);
            }
            else
            {
                session.sendMessage("Couldnt find target!");
                session.Entity.Target = null;
            }
        }
    }
}
