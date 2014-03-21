using Vanilla.World.Database;

namespace Vanilla.World.Components.GameObject.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public sealed class PSGameObjectQueryResponse : WorldPacket
    {
        public PSGameObjectQueryResponse(gameobject_template gameObjectTemplate)
            : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
        {
            this.Write((uint)gameObjectTemplate.entry);
            this.Write((uint)gameObjectTemplate.type);
            this.Write((uint)gameObjectTemplate.displayId);
            this.Write(Encoding.UTF8.GetBytes(gameObjectTemplate.name));
            this.Write((ushort)0);
            this.Write((byte)0);
            this.Write((byte)0);

            // 24 byte clear
            this.Write((short)0);
        }
    }
}