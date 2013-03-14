using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Milkshake.Net;
using Milkshake.Tools.Config;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandParser
    {
        private const string COMMANDS_NAMESPACE = "Milkshake.Tools.Chat.Commands";

        private static Dictionary<String, MethodInfo> CommandHandlers = new Dictionary<String, MethodInfo>();

        public static void Boot()
        {
            List<Type> nameSpaces = Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, COMMANDS_NAMESPACE, StringComparison.Ordinal)).ToList();
            nameSpaces.ForEach(n =>
            {
                List<MethodInfo> methods = n.GetMethods().ToList();
                methods.ForEach(m =>
                {
                    ChatCommandAttribute commandInfo = GetAttributes(m);
                    if(commandInfo != null) CommandHandlers.Add(commandInfo.ChatCommand, m);
                });
            });
        }

        private static ChatCommandAttribute GetAttributes(MethodInfo method)
        {
            Object[] attributes = method.GetCustomAttributes(typeof (ChatCommandAttribute), false);
            return (attributes.Length > 0) ? attributes.First() as ChatCommandAttribute : null;
        }

        public static Boolean ExecuteCommand(WorldSession sender, String message)
        {
            message = message.Remove(0, INI.GetValue(ConfigValues.WORLD, ConfigValues.COMMAND_KEY).Length);
            List<String> args = message.ToLower().Split(' ').ToList();
            

            MethodInfo Command;

            if (CommandHandlers.TryGetValue(args[0], out Command))
            {
                args.RemoveAt(0);
                object[] CommandArguments = new object[] { sender, args.ToArray() };

                //Call method with null instance (all command methods are static)
                try
                {
                    Command.Invoke(null, CommandArguments);
                    return true;
                }
                catch (Exception e)
                {
                    sender.sendMessage("Command Errored: " + e.Message);
                    return false;
                }
            }
            return false;
        }
    }
}
