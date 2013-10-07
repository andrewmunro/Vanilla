using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game.Mail
{
    public enum MailResponseType
    {
        MAIL_SEND = 0,
        MAIL_MONEY_TAKEN = 1,
        MAIL_ITEM_TAKEN = 2,
        MAIL_RETURNED_TO_SENDER = 3,
        MAIL_DELETED = 4,
        MAIL_MADE_PERMANENT = 5
    };
}
