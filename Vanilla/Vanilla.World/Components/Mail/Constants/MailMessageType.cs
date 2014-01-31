namespace Vanilla.World.Components.Mail.Constants
{
    public enum MailMessageType
    {
        MAIL_NORMAL = 0,
        MAIL_AUCTION = 2,
        MAIL_CREATURE = 3,                                /// client send CMSG_CREATURE_QUERY on this mailmessagetype
        MAIL_GAMEOBJECT = 4,                                /// client send CMSG_GAMEOBJECT_QUERY on this mailmessagetype
        MAIL_ITEM = 5,                                /// client send CMSG_ITEM_QUERY on this mailmessagetype
    }
}
