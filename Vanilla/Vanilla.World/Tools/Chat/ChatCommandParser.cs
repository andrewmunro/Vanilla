namespace Vanilla.World.Tools.Chat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Vanilla.Core.Config;
    using Vanilla.Core.Logging;
    using Vanilla.World.Network;

    public class ChatCommandParser
    {
        private readonly List<ChatCommandNode> chatCommandNodes = new List<ChatCommandNode>();

        //TODO Cleanup parser and allow ignoring case.
        public ChatCommandParser()
        {
            foreach (var type in GetTypesWithChatCommandNode(Assembly.GetExecutingAssembly()))
            {
                ChatCommandNode node = GetNode(type);
                node.Method = type.GetMethod("Default");
                AddNode(node);

                node.CommandAttributes = new List<ChatCommandAttribute>();

                foreach (var method in GetMethodsWithChatCommandAttribute(type))
                {
                    ChatCommandAttribute chatCommandAttribute = GetAttribute(method);
                    chatCommandAttribute.Method = method;
                    node.CommandAttributes.Add(chatCommandAttribute);
                }
            }
        }

        public void AddNode(ChatCommandNode node)
        {
            this.chatCommandNodes.Add(node);
        }

        public void RemoveNode(ChatCommandNode node)
        {
            this.chatCommandNodes.Remove(node);
        }

        public void RemoveNode(String nodeName)
        {
            this.chatCommandNodes.Remove(this.chatCommandNodes.FirstOrDefault(n => n.Name == nodeName));
        }

        private IEnumerable<MethodInfo> GetMethodsWithChatCommandAttribute(Type type)
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.GetCustomAttributes(typeof(ChatCommandAttribute), true).Length > 0)
                {
                    yield return method;
                }
            }
        }

        private IEnumerable<Type> GetTypesWithChatCommandNode(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(ChatCommandNode), true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        private ChatCommandNode GetNode(Type type)
        {
            Object[] attributes = type.GetCustomAttributes(typeof(ChatCommandNode), false);
            return (attributes.Length > 0) ? attributes.First() as ChatCommandNode : null;
        }

        private ChatCommandAttribute GetAttribute(MethodInfo method)
        {
            Object[] attributes = method.GetCustomAttributes(typeof (ChatCommandAttribute), false);
            return (attributes.Length > 0) ? attributes.First() as ChatCommandAttribute : null;
        }

        public Boolean ExecuteCommand(WorldSession sender, String message)
        {
            //Remove the chat command key
            message = message.Remove(0, Config.GetValue(ConfigSections.WORLD, ConfigValues.COMMAND_KEY).Length);
            List<String> args = message.ToLower().Split(' ').ToList();

            ChatCommandNode commandNode = this.chatCommandNodes.FirstOrDefault(node => node.Name == args[0]);

            if (commandNode != null)
            {
                //remove the command node.
                args.RemoveAt(0);

                ChatCommandAttribute commandAttribute = args.Count > 0 ? commandNode.CommandAttributes.FirstOrDefault(attribute => attribute.Name == args[0]) : null;

                if (commandAttribute != null)
                {
                    //remove the attribute
                    args.RemoveAt(0);

                    object[] commandArguments = { sender, args.ToArray() };

                    //Call method with null instance (all command methods are static)
                    try
                    {
                        commandAttribute.Method.Invoke(null, commandArguments);
                        Log.Print(LogType.Debug, "Player " + sender.Player.Character.Name + " used command " + commandNode.Name + " " + commandAttribute.Name);
                        return true;
                    }
                    catch (Exception e)
                    {
                        Log.Print(LogType.Error, "Command Errored");
                        Log.Print(LogType.Error, e.StackTrace);
                        sender.SendMessage("** " + commandNode.Name + " commands **");
                        this.SendCommandMessage(sender, commandAttribute);
                        return false;
                    }
                }
                if (commandNode.Method != null)
                {
                    object[] commandArguments = { sender, args.ToArray() };

                    try
                    {
                        commandNode.Method.Invoke(null, commandArguments);
                        Log.Print(LogType.Debug, "Player " + sender.Player.Character.Name + " used command " + commandNode.Name + " Default");
                        return true;
                    }
                    catch (Exception)
                    {
                        Log.Print(LogType.Error, "Error using command: " + commandNode.Name);
                        Log.Print(LogType.Error, "Make sure the method passed in AddChatCommand is static!");
                        return false;
                    }
                }
                sender.SendMessage("** " + commandNode.Name + " commands **");
                commandNode.CommandAttributes.ForEach(a => this.SendCommandMessage(sender, a));
                return false;
            }
            sender.SendMessage("** commands **");
            this.chatCommandNodes.ForEach(n => this.SendCommandMessage(sender, n));
            return false;
        }

        private void SendCommandMessage(WorldSession session, ChatCommandBase cmd)
        {
            session.SendMessage(cmd.Name + " - " + cmd.Description);
        }
    }
}
