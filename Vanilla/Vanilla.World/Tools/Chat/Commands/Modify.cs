using PropertyChanged;

using Vanilla.World.Components.Misc.Packets.Outgoing;

namespace Vanilla.World.Tools.Chat.Commands
{
    using System;
    using Vanilla.World.Components.Update.Constants;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Constants;
    using Vanilla.World.Game.Entity.Object.Creature;
    using Vanilla.World.Game.Entity.Object.Player;
    using Vanilla.World.Game.Entity.Object.Unit;
    using Vanilla.World.Network;

    [ChatCommandNode("modify", "Modify commands")]
    public class Modify
    {
        public static void Default(WorldSession session, string[] args)
        {
            if (args.Length == 1 && args[0].ToLower() == "list")
            {
                session.SendMessage("List");
            }
            else if(args.Length == 2)
            {
                string attributeName = args[0].ToLower();
                string attributeValue = args[1];

                // If player isn't targeting. Target self
                IUnitEntity entity = session.Player.Target ?? session.Player;

                //TODO Fix horrible hack.
                UnitInfo info = entity.ObjectGUID.TypeID == TypeID.TYPEID_PLAYER ? (UnitInfo)((PlayerEntity)entity).Info : ((CreatureEntity)entity).Info;

                bool unknownAttribute = false;

                switch (attributeName)
                {
                    case "scale":
                        info.Scale = float.Parse(attributeValue);
                        break;

                    case "health":
                        info.Health = int.Parse(attributeValue);
                        break;

                    case "level":
                        info.Level = int.Parse(attributeValue);
                        break;

                    case "xp":
                        (info as PlayerInfo).XP = int.Parse(attributeValue);
                        break;

                    case "model":
                        info.DisplayID = int.Parse(attributeValue);
                        break;

                    case "money":
                        int moneyToAdd = int.Parse(attributeValue) < 0x7fffffff ? int.Parse(attributeValue) : 0x7fffffff;
                        (info as PlayerInfo).Money += moneyToAdd;
                        session.Player.Character.money += moneyToAdd;
                        break;

                    case "standstate":
                        info.StandState = (byte)int.Parse(attributeValue);
                        break;

                    case "speed":
                        info.WalkSpeed = float.Parse(attributeValue);
                        session.SendPacket(new PSForceRunSpeedChange(entity.ObjectGUID, info.WalkSpeed));
                        break;
                    default:
                        unknownAttribute = true;
                        break;
                }

                if (unknownAttribute)
                {
                    session.SendMessage("Attribute '" + attributeName + "' was unknown");
                }
                else
                {
                    session.SendMessage("Applied " + attributeName + " = " + attributeValue + "");
                }
            }
        }
    }
}