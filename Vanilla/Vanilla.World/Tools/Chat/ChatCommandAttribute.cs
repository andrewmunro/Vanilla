namespace Vanilla.World.Tools.Chat
{
    public class ChatCommandAttribute : ChatCommandBase
    {
        public ChatCommandAttribute(string name, string description = "") : base(name,  description) { }
    }
}
