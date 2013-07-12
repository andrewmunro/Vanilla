using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandNode : ChatCommandBase
    {
        public List<ChatCommandAttribute> CommandAttributes { get; set; }

        public ChatCommandNode(string name, string description = "") : base(name, description) { }
    }
}
