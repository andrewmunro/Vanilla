using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandAttribute : ChatCommandBase
    {
        public ChatCommandAttribute(string name, string description = "") : base(name,  description) { }
    }
}
