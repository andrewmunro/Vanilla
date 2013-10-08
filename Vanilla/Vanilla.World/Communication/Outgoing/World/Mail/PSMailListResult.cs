using System;
using System.Collections.Generic;
using Vanilla.World.Game.Constants.Game.Mail;
using Vanilla.World.Network;
using Vanilla.World.Tools.Database.Helpers;
using Vanilla.World.Tools.Extensions;
using Vanilla.World.Tools.Shared;

namespace Vanilla.World.Communication.Outgoing.World.Mail
{
    using Vanilla.Core.Opcodes;

    public class PSMailListResult : ServerPacket
    {
        public PSMailListResult(List<CharacterMail> MailList) : base(WorldOpcodes.SMSG_MAIL_LIST_RESULT)
        {
            if (MailList.Count > 254) throw new NotImplementedException();

            for (int i = 0; i < MailList.Count; i++)
            {
                CharacterMail Mail = MailList[i];

                if (Mail.Expire_Time < Environment.TickCount)
                {
                    DBMails.RemoveMail(Mail);
                    continue;
                }
                Write((uint) Mail.MailTemplateID);
                Write((byte) Mail.MessageType);

                switch (Mail.MessageType)
                {
                    case MailMessageType.MAIL_NORMAL:                               // sender guid
                        Write((int)new ObjectGUID((ulong)Mail.Sender).HighGUID);
                        break;
                    case MailMessageType.MAIL_CREATURE:
                    case MailMessageType.MAIL_GAMEOBJECT:
                    case MailMessageType.MAIL_AUCTION:
                        Write((uint)Mail.Sender);             // creature/gameobject entry, auction id
                        break;
                    case MailMessageType.MAIL_ITEM:                                 // item entry (?) sender = "Unknown", NYI
                        break;
                }

                this.WriteCString(Mail.Subject);
                Write((uint)Mail.ItemTextID);
                Write((uint)0);
                Write((uint)Mail.Stationery);
                
                //TODO Send Item in messages
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

                Write((uint)Mail.Money);
                Write((uint)Mail.COD);
                Write((uint)Mail.Checked);
                Write(((float)(Mail.Expire_Time - Environment.TickCount) / 86400000));
                Write((uint)Mail.MailTemplateID);
            }
        }
    }
}
    