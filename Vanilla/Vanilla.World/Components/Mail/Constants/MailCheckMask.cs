namespace Vanilla.World.Components.Mail.Constants
{
    public enum MailCheckMask
    {
        MAIL_CHECK_MASK_NONE = 0x00,                     /// Nothing.
        MAIL_CHECK_MASK_READ = 0x01,                     /// This mail was read.
        MAIL_CHECK_MASK_RETURNED = 0x02,                     /// This mail was returned. No allow return mail.
        MAIL_CHECK_MASK_COPIED = 0x04,                     /// This mail was copied. No allow make item copy from mail text.
        MAIL_CHECK_MASK_COD_PAYMENT = 0x08,                     /// This mail is payable on delivery.
        MAIL_CHECK_MASK_HAS_BODY = 0x10,                     /// This mail has body text.
    }
}
