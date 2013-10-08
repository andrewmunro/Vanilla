using System;
using Vanilla.World.Communication.Outgoing.World.Update;
using Vanilla.World.Game.Entitys;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    using Vanilla.Core.Opcodes;

    enum SpellCastFlags
    {
        CAST_FLAG_NONE = 0x00000000,
        CAST_FLAG_HIDDEN_COMBATLOG = 0x00000001,               // hide in combat log?
        CAST_FLAG_UNKNOWN2 = 0x00000002,
        CAST_FLAG_UNKNOWN3 = 0x00000004,
        CAST_FLAG_UNKNOWN4 = 0x00000008,
        CAST_FLAG_UNKNOWN5 = 0x00000010,
        CAST_FLAG_AMMO = 0x00000020,               // Projectiles visual
        CAST_FLAG_UNKNOWN7 = 0x00000040,               // !0x41 mask used to call CGTradeSkillInfo::DoRecast
        CAST_FLAG_UNKNOWN8 = 0x00000080,
        CAST_FLAG_UNKNOWN9 = 0x00000100,
    };

    public class PSSpellGo : ServerPacket
    {
        public PSSpellGo(PlayerEntity caster, PlayerEntity target, uint spellID) : base(WorldOpcodes.SMSG_SPELL_GO)
        {
            byte[] casterGUID = PSUpdateObject.GenerateGuidBytes((ulong)caster.ObjectGUID.RawGUID);
            byte[] targetGUID = PSUpdateObject.GenerateGuidBytes((ulong)target.ObjectGUID.RawGUID);

            PSUpdateObject.WriteBytes(this, casterGUID);
            PSUpdateObject.WriteBytes(this, casterGUID);
            Write((UInt32)spellID);
            Write((UInt16)SpellCastFlags.CAST_FLAG_UNKNOWN9); // Cast Flags!?
            Write((Byte)1); // Target Length
            Write((UInt64)target.ObjectGUID.RawGUID);
            Write((Byte)0); // End
            Write((UInt16)2); // TARGET_FLAG_UNIT
            PSUpdateObject.WriteBytes(this, targetGUID); // Packed GUID

        }
    }

}
