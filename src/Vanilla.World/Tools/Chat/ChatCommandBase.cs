using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandBase : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MethodInfo Method { get; set; }

        public ChatCommandBase(string name, string description = "")
        {
            Name = name;
            Description = description;
        }
    }
}
