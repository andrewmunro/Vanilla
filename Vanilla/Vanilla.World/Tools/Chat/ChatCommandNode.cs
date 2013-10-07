using System.Collections.Generic;

namespace Vanilla.World.Tools.Chat
{
    public class ChatCommandNode : ChatCommandBase
    {
        public List<ChatCommandAttribute> CommandAttributes { get; set; }

        public ChatCommandNode(string name, string description = "") : base(name, description) { }
    }
}
