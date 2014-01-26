using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.World.Components.Chat
{
    using Vanilla.World.Network;

    public class ChatChannel
    {
        public string Name;

        public string Password;

        public List<WorldSession> Sessions;

        public ChatChannel(String name, String password)
        {
            this.Name = name;
            this.Password = password;
            Sessions = new List<WorldSession>();
        }
    }
}
