namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using System;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Entity.Object.Creature;

    public class PSCreatureQueryResponse : WorldPacket
    {
        public PSCreatureQueryResponse(uint entry, CreatureEntity entity)
            : base(WorldOpcodes.SMSG_CREATURE_QUERY_RESPONSE)
        {
            this.Write(entry);
            this.WriteCString(entity.Name);
            this.WriteNullByte(3); // Name2,3,4

            if (entity.Template.subname == "\\N")
            {
                this.WriteNullByte(1);
            }
            else
            {
                this.WriteCString(entity.Template.subname);
            }

            this.Write((UInt32)entity.Template.type_flags);
            this.Write((UInt32)entity.Template.type);
            this.Write((UInt32)entity.Template.family);
            this.Write((UInt32)entity.Template.rank);
            this.WriteNullUInt(1);

            this.Write((UInt32)entity.Template.PetSpellDataId);
            this.Write((UInt32)entity.Creature.modelid);
            this.Write((UInt16)entity.Template.Civilian);
        }
    }
}