using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Spell
{
    #region

    using System;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Outgoing.World.Update;
    using Vanilla.World.Game.Entitys;

    #endregion

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
        #region Constructors and Destructors

        public PSSpellGo(PlayerEntity caster, PlayerEntity target, uint spellID)
            : base(WorldOpcodes.SMSG_SPELL_GO)
        {
            byte[] casterGUID = PSUpdateObject.GenerateGuidBytes(caster.ObjectGUID.RawGUID);
            byte[] targetGUID = PSUpdateObject.GenerateGuidBytes(target.ObjectGUID.RawGUID);

            PSUpdateObject.WriteBytes(this, casterGUID);
            PSUpdateObject.WriteBytes(this, casterGUID);
            Write(spellID);
            Write((ushort)SpellCastFlags.CAST_FLAG_UNKNOWN9); // Cast Flags!?
            Write((byte)1); // Target Length
            Write(target.ObjectGUID.RawGUID);
            Write((byte)0); // End
            Write((ushort)2); // TARGET_FLAG_UNIT
            PSUpdateObject.WriteBytes(this, targetGUID); // Packed GUID
        }

        #endregion
    }
}