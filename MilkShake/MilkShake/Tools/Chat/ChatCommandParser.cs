using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Milkshake.Net;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandParser
    {
        private static Dictionary<String, MethodInfo> CommandHandlers = new Dictionary<String, MethodInfo>();

        public static void Boot()
        {
            List<Type> nameSpaces = Assembly.GetExecutingAssembly().GetTypes().Where(t => String.Equals(t.Namespace, "Milkshake.Tools.Chat.Commands", StringComparison.Ordinal)).ToList();
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
            if (attributes.Length > 0) return attributes.First() as ChatCommandAttribute;
            return null;
        }

        public static Boolean ExecuteCommand(WorldSession sender, String message)
        {
            string[] args = message.ToLower().Split(' ');

            MethodInfo Command;

            if (CommandHandlers.TryGetValue(args[0], out Command))
            {
                object[] CommandArguments = new object[] { sender, args };

                //Call method with null instance (all command methods are static)
                Command.Invoke(null, CommandArguments);
                return true;
            }
            return false;
        }
    }
}
