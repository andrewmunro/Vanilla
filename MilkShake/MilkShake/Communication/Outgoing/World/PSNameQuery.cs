using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;

namespace Milkshake.Communication.Outgoing.World
{
    public class PSNameQuery : ServerPacket
    {
        public PSNameQuery(Character character) : base(Opcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            Write((uint)character.GUID);
            Write(Encoding.UTF8.GetBytes(character.Name + '\0'));
            Write(0);
            Write((uint)character.Race);
            Write((uint)character.Gender);
            Write((uint)character.Class);
        } 
    }
}
