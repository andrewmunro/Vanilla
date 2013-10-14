using Vanilla.Core.Network.Packet;

namespace Vanilla.World.Communication.Outgoing.World.Mail
{
    #region

    using System;
    using System.Collections.Generic;

    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Constants.Game.Mail;
    using Vanilla.World.Tools.Shared;

    #endregion

    public sealed class PSMailListResult : WorldPacket
    {
        #region Constructors and Destructors

        public PSMailListResult(List<mail> MailList)
            : base(WorldOpcodes.SMSG_MAIL_LIST_RESULT)
        {
            if (MailList.Count > 254)
            {
                throw new NotImplementedException();
            }

            for (int i = 0; i < MailList.Count; i++)
            {
                mail Mail = MailList[i];

                if (Mail.expire_time < Environment.TickCount)
                {
                    VanillaWorld.CharacterDatabase.Mails.Remove(Mail);
                    continue;
                }

                Write((uint)Mail.messageType);
                Write(Mail.messageType);

                switch ((MailMessageType)Mail.messageType)
                {
                    case MailMessageType.MAIL_NORMAL: // sender guid
                        Write((int)new ObjectGUID((ulong)Mail.sender).HighGUID);
                        break;
                    case MailMessageType.MAIL_CREATURE:
                    case MailMessageType.MAIL_GAMEOBJECT:
                    case MailMessageType.MAIL_AUCTION:
                        Write((uint)Mail.sender); // creature/gameobject entry, auction id
                        break;
                    case MailMessageType.MAIL_ITEM: // item entry (?) sender = "Unknown", NYI
                        break;
                }

                this.WriteCString(Mail.subject);
                Write((uint)Mail.itemTextId);
                Write((uint)0);
                Write((uint)Mail.stationery);

                // TODO Send Item in messages
                /*                Item* item = (*itr)->items.size() > 0 ? _player->GetMItem((*itr)->items[0].item_guid) : NULL;
                data << uint32(item ? item->GetEntry() : 0);        // entry
                // permanent enchantment
                data << uint32(item ? item->GetEnchantmentId((EnchantmentSlot)PERM_ENCHANTMENT_SLOT) : 0);
                // can be negative
                data << uint32(item ? item->GetItemRandomPropertyId() : 0);
                // unk
                data << uint32(item ? item->GetItemSuffixFactor() : 0);
                data << uint8(item ? item->GetCount() : 0);         // stack count
                data << uint32(item ? item->GetSpellCharges() : 0); // charges
                // durability
                data << uint32(item ? item->GetUInt32Value(ITEM_FIELD_MAXDURABILITY) : 0);
                // durability
                data << uint32(item ? item->GetUInt32Value(ITEM_FIELD_DURABILITY) : 0);
                data << uint32((*itr)->money);                      // copper
                data << uint32((*itr)->COD);                        // Cash on delivery
                data << uint32((*itr)->checked);                    // flags
                data << float(float((*itr)->expire_time - time(NULL)) / float(DAY));// Time
                data << uint32((*itr)->mailTemplateId); */
                this.WriteNullUInt(4);
                Write((byte)0);
                this.WriteNullUInt(3);

                Write((uint)Mail.money);
                Write((uint)Mail.cod);
                Write((uint)Mail.@checked);
                Write((float)(Mail.expire_time - Environment.TickCount) / 86400000);
                Write((uint)Mail.mailTemplateId);
            }
            VanillaWorld.CharacterDatabase.SaveChanges();
        }

        #endregion
    }
}