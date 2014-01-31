namespace Vanilla.World.Game.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Database.Character.Models;

    using Vanilla.Core.Constants.Character;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Incoming.World.Mail;
    using Vanilla.World.Communication.Outgoing.World.Mail;
    using Vanilla.World.Game.Constants.Game;
    using Vanilla.World.Game.Constants.Game.Mail;
    using Vanilla.World.Game.Handlers;
    using Vanilla.World.Network;

    public class MailManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCGetMailList>(WorldOpcodes.CMSG_GET_MAIL_LIST, OnGetMailList);
            WorldDataRouter.AddHandler<PCSendMail>(WorldOpcodes.CMSG_SEND_MAIL, OnSendMail);
            WorldDataRouter.AddHandler<PCSendMail>(WorldOpcodes.CMSG_MAIL_RETURN_TO_SENDER, OnReturnMailToSender);
        }

        private static void OnReturnMailToSender(WorldSession session, PCSendMail handler)
        {
            throw new NotImplementedException();
        }

        private static void OnSendMail(WorldSession session, PCSendMail mail)
        {
            Character reciever = VanillaWorld.CharacterDatabase.Characters.Single(cs => cs.Name == mail.Reciever);
            var result = MailResponseResult.MAIL_OK;
            if (reciever == null)
            {
                result = MailResponseResult.MAIL_ERR_RECIPIENT_NOT_FOUND;
            }
            else if (reciever.Name == session.Character.Name)
            {
                result = MailResponseResult.MAIL_ERR_CANNOT_SEND_TO_SELF;
            }
            else if (session.Character.Money < mail.Money + 30)
            {
                result = MailResponseResult.MAIL_ERR_NOT_ENOUGH_MONEY;
            }
            else if (VanillaWorld.CharacterDatabase.Mails.Where(m => m.receiver == reciever.GUID).ToArray().Length > 100)
            {
                result = MailResponseResult.MAIL_ERR_RECIPIENT_CAP_REACHED;
            }
            else if (GetFaction(reciever) != GetFaction(session.Character))
            {
                result = MailResponseResult.MAIL_ERR_NOT_YOUR_TEAM;
            }

            if (mail.ItemGUID > 0)
            {
                throw new NotImplementedException();
            }

            session.SendPacket(new PSSendMailResult(0, MailResponseType.MAIL_SEND, result));

            if (result == MailResponseResult.MAIL_OK)
            {
                session.Character.Money -= (int)(mail.Money + 30);
                //TODO Implement
/*                VanillaWorld.CharacterDatabase.Mails.Add(
                    new mail(
                        {
                            messageType = (byte)MailMessageType.MAIL_NORMAL,
                            deliver_time = 0,
                            expire_time = (int)GameUnits.DAY * 30,
                            @checked =
                                mail.Body != ""
                                    ? (byte)MailCheckMask.MAIL_CHECK_MASK_HAS_BODY
                                    : (byte)MailCheckMask.MAIL_CHECK_MASK_COPIED,
                            cod = (int)mail.COD,
                            has_items = 0,
                            itemTextId = 0,
                            money = (int)mail.Money,
                            sender = session.Character.GUID,
                            receiver = reciever.GUID,
                            subject = mail.Subject,
                            stationery = (sbyte)MailStationery.MAIL_STATIONERY_DEFAULT,
                            mailTemplateId = 0
                        }
                    )
                );*/

            }
        }

        private static string GetFaction(Character character)
        {
            if (character.Race == (byte)RaceID.Human ||
            character.Race == (byte)RaceID.Dwarf || character.Race == (byte)RaceID.Gnome
            || character.Race == (byte)RaceID.NightElf) return "Alliance";
            return "Horde";
        }

        private static void OnGetMailList(WorldSession session, PCGetMailList handler)
        {
            List<Mail> Mails = VanillaWorld.CharacterDatabase.Mails.Where(m => m.receiver == session.Character.GUID).ToList();
            session.SendPacket(new PSMailListResult(Mails));
        }
    }
}
