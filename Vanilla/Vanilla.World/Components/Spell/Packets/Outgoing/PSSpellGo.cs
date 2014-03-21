namespace Vanilla.World.Components.Spell.Packets.Outgoing
{
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Update.Packets.Outgoing;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Object.Player;

    internal enum SpellCastFlags
    {
        CAST_FLAG_NONE = 0x00000000, 

        CAST_FLAG_HIDDEN_COMBATLOG = 0x00000001, // hide in combat log?

        CAST_FLAG_UNKNOWN2 = 0x00000002, 

        CAST_FLAG_UNKNOWN3 = 0x00000004, 

        CAST_FLAG_UNKNOWN4 = 0x00000008, 

        CAST_FLAG_UNKNOWN5 = 0x00000010, 

        CAST_FLAG_AMMO = 0x00000020, // Projectiles visual

        CAST_FLAG_UNKNOWN7 = 0x00000040, // !0x41 mask used to call CGTradeSkillInfo::DoRecast

        CAST_FLAG_UNKNOWN8 = 0x00000080, 

        CAST_FLAG_UNKNOWN9 = 0x00000100, 
    };

    public sealed class PSSpellGo : WorldPacket
    {
        public PSSpellGo(PlayerEntity caster, IUnitEntity target, uint spellID)
            : base(WorldOpcodes.SMSG_SPELL_GO)
        {
            this.WritePackedUInt64(caster.ObjectGUID.RawGUID);
            this.WritePackedUInt64(target.ObjectGUID.RawGUID);

            this.Write(spellID);
            this.Write((ushort)SpellCastFlags.CAST_FLAG_UNKNOWN9); // Cast Flags!?
            this.Write((byte)1); // Target Length
            this.Write(target.ObjectGUID.RawGUID);
            this.Write((byte)0); // End
            this.Write((ushort)2); // TARGET_FLAG_UNIT
            this.WritePackedUInt64(target.ObjectGUID.RawGUID);
        }
    }
}