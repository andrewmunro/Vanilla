namespace Vanilla.World.Components.GameObject.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.World.Models;

    public sealed class PSGameObjectQueryResponse : WorldPacket
    {
        public PSGameObjectQueryResponse(GameObjectTemplate gameObjectTemplate)
            : base(WorldOpcodes.SMSG_GAMEOBJECT_QUERY_RESPONSE)
        {
            this.Write((uint)gameObjectTemplate.Entry);
            this.Write((uint)gameObjectTemplate.Type);
            this.Write((uint)gameObjectTemplate.DisplayId);
            this.Write(Encoding.UTF8.GetBytes(gameObjectTemplate.Name));
            this.Write((ushort)0);
            this.Write((byte)0);
            this.Write((byte)0);

            // 24 byte clear
            this.Write((short)0);
        }
    }
}