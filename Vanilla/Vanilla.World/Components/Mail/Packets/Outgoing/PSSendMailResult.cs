namespace Vanilla.World.Components.Mail.Packets.Outgoing
{
    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;
    using Vanilla.World.Components.Mail.Constants;

    public class PSSendMailResult : WorldPacket
    {
        public PSSendMailResult(
            uint mailID, 
            MailResponseType mailAction, 
            MailResponseResult mailError, 
            uint equipError = 0, 
            uint itemGUID = 0, 
            uint itemCount = 0)
            : base(WorldOpcodes.SMSG_SEND_MAIL_RESULT)
        {
            this.Write(mailID);
            this.Write((uint)mailAction);
            this.Write((uint)mailError);
            this.Write((uint)mailError);

            if (mailError == MailResponseResult.MAIL_ERR_EQUIP_ERROR)
            {
                this.Write(equipError);
            }
            else if (mailAction == MailResponseType.MAIL_ITEM_TAKEN)
            {
                this.Write(itemGUID); // item guid low?
                this.Write(itemCount); // item count?
            }
        }
    }
}