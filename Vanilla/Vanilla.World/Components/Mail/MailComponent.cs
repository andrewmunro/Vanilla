namespace Vanilla.World.Components.Mail
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Constants;
    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.IO;
    using Vanilla.Core.Opcodes;
    using Vanilla.Database.Character.Models;
    using Vanilla.World.Components.Mail.Constants;
    using Vanilla.World.Components.Mail.Packets.Incoming;
    using Vanilla.World.Components.Mail.Packets.Outgoing;
    using Vanilla.World.Network;

    public class MailComponent : WorldServerComponent
    {
        public IRepository<Character> Characters { get { return Core.CharacterDatabase.GetRepository<Character>(); } }
        public IRepository<Mail> Mails { get { return Core.CharacterDatabase.GetRepository<Mail>(); } }

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
            Character reciever = Characters.SingleOrDefault(c => c.Name == packet.Reciever);
            var result = MailResponseResult.MAIL_OK;
            if (reciever == null)
            {
                result = MailResponseResult.MAIL_ERR_RECIPIENT_NOT_FOUND;
            }
            else if (reciever.Name == session.Player.Name)
            {
                result = MailResponseResult.MAIL_ERR_CANNOT_SEND_TO_SELF;
            }
            else if (session.Player.Character.Money < packet.Money + 30)
            {
                result = MailResponseResult.MAIL_ERR_NOT_ENOUGH_MONEY;
            }
            else if (Mails.Where(m => m.Receiver == reciever.GUID).ToArray().Length > 100)
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
                session.Player.Character.Money -= (int)(packet.Money + 30);
                Mails.Add(
                    new Mail()
                        {
                            MessageType = (byte)MailMessageType.MAIL_NORMAL,
                            DeliverTime = 0,
                            ExpireTime = (int)GameUnits.DAY * 30,
                            Checked =
                                packet.Body != ""
                                    ? (byte)MailCheckMask.MAIL_CHECK_MASK_HAS_BODY
                                    : (byte)MailCheckMask.MAIL_CHECK_MASK_COPIED,
                            Cod = (int)packet.COD,
                            HasItems = 0,
                            ItemTextId = 0,
                            Money = (int)packet.Money,
                            Sender = session.Player.Character.GUID,
                            Receiver = reciever.GUID,
                            Subject = packet.Subject,
                            Stationery = (sbyte)MailStationery.MAIL_STATIONERY_DEFAULT,
                            MailTemplateId = 0
                        });
            }
        }

        private string GetFaction(Character character)
        {
            if (character.Race == (byte)RaceID.Human ||
            character.Race == (byte)RaceID.Dwarf || character.Race == (byte)RaceID.Gnome
            || character.Race == (byte)RaceID.NightElf) return "Alliance";
            return "Horde";
        }

        private void OnGetMailList(WorldSession session, PCGetMailList packet)
        {
            var mailList = this.Mails.Where(m => m.Receiver == packet.GUID).ToList();
            this.RemoveExpiredMail(mailList);
            
            session.SendPacket(new PSMailListResult(mailList));
        }

        private void RemoveExpiredMail(List<Mail> mailList)
        {
            var expiredMail = mailList.Where(m => m.ExpireTime < Environment.TickCount).ToList();
            expiredMail.ForEach(
                m =>
                    {
                        this.Mails.Delete(m);
                        mailList.Remove(m);
                    });
        }
    }
}
