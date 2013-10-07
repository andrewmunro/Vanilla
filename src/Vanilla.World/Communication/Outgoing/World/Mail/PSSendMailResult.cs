using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants.Game.Mail;
using Milkshake.Network;

namespace Milkshake.Communication.Outgoing.World.Mail
{
    public class PSSendMailResult : ServerPacket
    {
        public PSSendMailResult(uint mailID, MailResponseType mailAction, MailResponseResult mailError, uint equipError = 0, uint itemGUID = 0, uint itemCount = 0)
            : base(WorldOpcodes.SMSG_SEND_MAIL_RESULT)
        {
            Write((uint)mailID);
            Write((uint)mailAction);
            Write((uint)mailError);
            Write((uint)mailError);

            if (mailError == MailResponseResult.MAIL_ERR_EQUIP_ERROR) Write((uint)equipError);
            else if (mailAction == MailResponseType.MAIL_ITEM_TAKEN)
            {
                Write((uint)itemGUID); // item guid low?
                Write((uint)itemCount); // item count?
            }
        }
    }
}
