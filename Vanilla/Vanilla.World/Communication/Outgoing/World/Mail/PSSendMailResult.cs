namespace Vanilla.World.Communication.Outgoing.World.Mail
{
    #region

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Game.Constants.Game.Mail;

    #endregion

    public class PSSendMailResult : ServerPacket
    {
        #region Constructors and Destructors

        public PSSendMailResult(
            uint mailID, 
            MailResponseType mailAction, 
            MailResponseResult mailError, 
            uint equipError = 0, 
            uint itemGUID = 0, 
            uint itemCount = 0)
            : base(WorldOpcodes.SMSG_SEND_MAIL_RESULT)
        {
            Write(mailID);
            Write((uint)mailAction);
            Write((uint)mailError);
            Write((uint)mailError);

            if (mailError == MailResponseResult.MAIL_ERR_EQUIP_ERROR)
            {
                Write(equipError);
            }
            else if (mailAction == MailResponseType.MAIL_ITEM_TAKEN)
            {
                Write(itemGUID); // item guid low?
                Write(itemCount); // item count?
            }
        }

        #endregion
    }
}