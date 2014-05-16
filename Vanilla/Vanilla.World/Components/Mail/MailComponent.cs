using Vanilla.Character.Database;
using Vanilla.World.Components.Auth;
using Vanilla.World.Components.Chat;

namespace Vanilla.World.Components.Mail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Constants;
    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Mail.Constants;
    using Vanilla.World.Components.Mail.Packets.Incoming;
    using Vanilla.World.Components.Mail.Packets.Outgoing;
    using Vanilla.World.Network;

    public class MailComponent : WorldServerComponent
    {
        public IRepository<character> Characters { get { return Core.CharacterDatabase.GetRepository<character>(); } }
        public IRepository<mail> Mails { get { return Core.CharacterDatabase.GetRepository<mail>(); } }

        public MailComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            Router.AddHandler<PCGetMailList>(WorldOpcodes.CMSG_GET_MAIL_LIST, OnGetMailList);
            Router.AddHandler<PCSendMail>(WorldOpcodes.CMSG_SEND_MAIL, OnSendMail);
            Router.AddHandler<PCSendMail>(WorldOpcodes.CMSG_MAIL_RETURN_TO_SENDER, OnReturnMailToSender);
        }

        private void OnReturnMailToSender(WorldSession session, PCSendMail packet)
        {
            throw new NotImplementedException();
        }

        private void OnSendMail(WorldSession session, PCSendMail packet)
        {
            character reciever = Characters.SingleOrDefault(c => c.name == packet.Reciever);
            var result = MailResponseResult.MAIL_OK;
            if (reciever == null)
            {
                result = MailResponseResult.MAIL_ERR_RECIPIENT_NOT_FOUND;
            }
            else if (reciever.name == session.Player.Name)
            {
                result = MailResponseResult.MAIL_ERR_CANNOT_SEND_TO_SELF;
            }
            else if (session.Player.Character.money < packet.Money + 30)
            {
                result = MailResponseResult.MAIL_ERR_NOT_ENOUGH_MONEY;
            }
            else if (Mails.Where(m => m.receiver == reciever.guid).ToArray().Length > 100)
            {
                result = MailResponseResult.MAIL_ERR_RECIPIENT_CAP_REACHED;
            }
            else if (GetFaction(reciever) != GetFaction(session.Player.Character))
            {
                result = MailResponseResult.MAIL_ERR_NOT_YOUR_TEAM;
            }

            if (packet.ItemGUID > 0)
            {
                throw new NotImplementedException();
            }

            session.SendPacket(new PSSendMailResult(0, MailResponseType.MAIL_SEND, result));

            if (result == MailResponseResult.MAIL_OK)
            {
                session.Player.Character.money -= (int)(packet.Money + 30);
                Mails.Add(
                    new mail()
                        {
                            messageType = (byte)MailMessageType.MAIL_NORMAL,
                            deliver_time = 0,
                            expire_time = (int)GameUnits.DAY * 30,
                            @checked = 
                                packet.Body != ""
                                    ? (byte)MailCheckMask.MAIL_CHECK_MASK_HAS_BODY
                                    : (byte)MailCheckMask.MAIL_CHECK_MASK_COPIED,
                            cod = (int)packet.COD,
                            has_items = 0,
                            itemTextId = 0,
                            money = (int)packet.Money,
                            sender = session.Player.Character.guid,
                            receiver = reciever.guid,
                            subject = packet.Subject,
                            stationery = (sbyte)MailStationery.MAIL_STATIONERY_DEFAULT,
                            mailTemplateId = 0
                        });
            }
        }

        private string GetFaction(character character)
        {
            if (character.race == (byte)RaceID.Human ||
            character.race == (byte)RaceID.Dwarf || character.race == (byte)RaceID.Gnome
            || character.race == (byte)RaceID.NightElf) return "Alliance";
            return "Horde";
        }

        private void OnGetMailList(WorldSession session, PCGetMailList packet)
        {
            var mailList = this.Mails.Where(m => m.receiver == packet.GUID).ToList();
            this.RemoveExpiredMail(mailList);
            
            session.SendPacket(new PSMailListResult(mailList));
        }

        private void RemoveExpiredMail(List<mail> mailList)
        {
            var expiredMail = mailList.Where(m => m.expire_time < Environment.TickCount).ToList();
            expiredMail.ForEach(
                m =>
                    {
                        this.Mails.Delete(m);
                        mailList.Remove(m);
                    });
        }
    }
}
