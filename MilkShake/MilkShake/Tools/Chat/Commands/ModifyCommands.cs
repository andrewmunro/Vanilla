using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Net;
using Milkshake.Game.Entitys;
using System.Reflection;

namespace Milkshake.Tools.Chat.Commands
{
    public class ModifyCommands
    {
        [ChatCommand("modify", "Modify entity attributes")]
        public static void Lookup(WorldSession session, string[] args)
        {
            if (args.Length == 2 && args[1].ToLower() == "list")
            {
                session.sendMessage("List");
            }
            else if(args.Length == 3)
            {
                string attributeName = args[1].ToLower();
                string attributeValue = args[2];

                // If player isn't targeting. Target self
                PlayerEntity entity = (session.Entity.Target == null) ? session.Entity : session.Entity.Target;

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
