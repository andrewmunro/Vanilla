using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Core.IO;
using Vanilla.Core.Network.IO;
using Vanilla.Core.Opcodes;
using Vanilla.Database.Character.Models;
using Vanilla.Login.Database.Models;
using Vanilla.World.Components.Auth.Packets.Incoming;
using Vanilla.World.Components.Char.Packets.Outgoing;
using Vanilla.World.Network;

namespace Vanilla.World.Components.Char
{
    public class CharacterComponent : WorldServerComponent
    {
        protected IRepository<Character> Characters { get { return Core.CharacterDatabase.GetRepository<Character>(); } }

        public CharacterComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler(WorldOpcodes.CMSG_CHAR_ENUM, OnCharEnum);
        }

        private void OnCharEnum(WorldSession session, PacketReader reader)
        {
            session.SendPacket(new PSCharEnum(new List<Character>()));
        }
    }
}
