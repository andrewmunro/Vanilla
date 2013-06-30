using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Net;
using Milkshake.Game.Entitys;
using System.Reflection;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Game.Constants.Character;

namespace Milkshake.Tools.Chat.Commands
{
    public class ModifyCommands
    {
        [ChatCommand("modify", "Modify entity attributes")]
        public static void Modify(WorldSession session, string[] args)
        {
            if (args.Length == 1 && args[0].ToLower() == "list")
            {
                session.sendMessage("List");
            }
            else if(args.Length == 2)
            {
                string attributeName = args[0].ToLower();
                string attributeValue = args[1];

                // If player isn't targeting. Target self
                PlayerEntity entity = session.Entity.Target ?? session.Entity;

                bool unknownAttribute = false;

                switch (attributeName)
                {
                    case "scale":
                        entity.Scale = float.Parse(attributeValue);
                        break;

                    case "health":
                        entity.Health = int.Parse(attributeValue);
                        break;

                    case "level":
                        entity.Level = int.Parse(attributeValue);
                        break;

                    case "xp":
                        entity.XP = int.Parse(attributeValue);
                        break;

                    case "gender":
                        entity.SetUpdateField<byte>((int)EUnitFields.UNIT_FIELD_BYTES_0, (byte)int.Parse(attributeValue), 2);
                        break;

                    default:
                        unknownAttribute = true;
                        break;
                }

                if (unknownAttribute)
                {
                    session.sendMessage("Attribute '" + attributeName + "' was unknown");
                }
                else
                {
                    session.sendMessage("Applied " + attributeName + " = " + attributeValue + "");
                }
            }
        }
    }
}
