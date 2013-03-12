    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.Chat
{
    public class ChatCommandAttribute : Attribute
    {
        public string ChatCommand { get; set; }
        public string Description { get; set; }

        public ChatCommandAttribute(string chatCommand, string description = "")
        {
            ChatCommand = chatCommand;
            Description = description;
        }
    }
}
