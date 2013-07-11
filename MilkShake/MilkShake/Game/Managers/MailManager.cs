using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.World.Mail;
using Milkshake.Communication.Outgoing.World.Mail;
using Milkshake.Game.Handlers;
using Milkshake.Net;
using Milkshake.Tools.Database.Helpers;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Game.Managers
{
    public class MailManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCGetMailList>(WorldOpcodes.CMSG_GET_MAIL_LIST, OnGetMailList);
        }

        private static void OnGetMailList(WorldSession session, PCGetMailList handler)
        {
            List<CharacterMail> Mails = DBMails.GetCharacterMails(session.Character);
            session.sendPacket(new PSMailListResult(Mails));
        }
    }
}
