namespace Vanilla.World.Components.Mail.Packets.Outgoing
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.IO;
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.Mail.Constants;
    using Vanilla.World.Game.Entity;
    using Vanilla.World.Game.Entity.Constants;

    public sealed class PSMailListResult : WorldPacket
    {
        public PSMailListResult(List<Mail> mailList) : base(WorldOpcodes.SMSG_MAIL_LIST_RESULT)
        {
            if (mailList.Count > 254)
            {
                throw new NotImplementedException();
            }

            foreach (var mail in mailList)
            {
                this.Write((uint)mail.MessageType);
                this.Write(mail.MessageType);

                switch ((MailMessageType)mail.MessageType)
                {
                    case MailMessageType.MAIL_NORMAL: // sender guid
                        this.Write((int)new ObjectGUID((ulong)mail.Sender, (TypeID)25).HighGUID);
                        break;
                    case MailMessageType.MAIL_CREATURE:
                    case MailMessageType.MAIL_GAMEOBJECT:
                    case MailMessageType.MAIL_AUCTION:
                        this.Write((uint)mail.Sender); // creature/gameobject entry, auction id
                        break;
                    case MailMessageType.MAIL_ITEM: // item entry (?) sender = "Unknown", NYI
                        break;
                }

                this.WriteCString(mail.Subject);
                this.Write((uint)mail.ItemTextId);
                this.Write((uint)0);
                this.Write((uint)mail.Stationery);

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
                this.Write((byte)0);
                this.WriteNullUInt(3);

                this.Write((uint)mail.Money);
                this.Write((uint)mail.Cod);
                this.Write((uint)mail.Checked);
                this.Write((float)(mail.ExpireTime - Environment.TickCount) / 86400000);
                this.Write((uint)mail.MailTemplateId);
            }
        }
    }
}