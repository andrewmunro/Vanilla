using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World
{
    #region

    using System.Text;
    using Character.Database.Models;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public class PSNameQueryResponse : WorldPacket
    {
        #region Constructors and Destructors

        public PSNameQueryResponse(Character character)
            : base(WorldOpcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            Write((ulong)character.GUID);
            Write(Encoding.UTF8.GetBytes(character.Name + '\0'));
            Write((byte)0); // realm name for cross realm BG usage
            Write((uint)character.Race);
            Write((uint)character.Gender);
            Write((uint)character.Class);
        }

        #endregion
    }
}