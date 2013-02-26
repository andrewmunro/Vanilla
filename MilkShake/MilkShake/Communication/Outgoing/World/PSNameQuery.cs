using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Database;
using Milkshake.Tools.Database.Tables;
using Milkshake.Communication.Outgoing.World.Update;

namespace Milkshake.Communication.Outgoing.World
{
    public class PSNameQuery : ServerPacket
    {
        public PSNameQuery(Character character) : base(Opcodes.SMSG_NAME_QUERY_RESPONSE)
        {
            Write((ulong)character.GUID);
            Write(Encoding.UTF8.GetBytes(character.Name + '\0'));
            Write((byte)0); // realm name for cross realm BG usage
            Write((uint)character.Race);
            Write((uint)character.Gender);
            Write((uint)character.Class);
        } 
    }
}
