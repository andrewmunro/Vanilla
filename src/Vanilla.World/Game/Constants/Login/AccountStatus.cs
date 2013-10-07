namespace Milkshake.Game.Constants
{
    public enum AccountStatus : byte
    {
        Ok = 0x00,               // Successfully logged in.
        IPBanned = 0x01,         // "Unable to connect"
        Banned = 0x03,           // "This World of Warcraft account has been closed and is no longer in service -- Please check the registered email address of this account for further information."
        UnknownAccount = 0x04,
        AlreadyOnline = 0x06,    // "This account is already logged into World of Warcraft. Please check the spelling and try again."
        NoTimeLeft = 0x07,       // "You have used up your prepaid time for this account. Please purchase more to continue playing"
        DBBusy = 0x08,           // "Could not log in to World of Warcraft at this time. Please try again later."
        BadVersion = 0x09,       // "Unable to validate game version. This may be caused by file corruption or the interference of another program.  Please visit www.blizzard.com/support/wow/ for more information and possible solutions to this issue."
        DownloadFile = 0x0A,     // Not official name
        AccountFrozen = 0x0C,
        ParentalControl = 0x0F   // "Access to this account has been blocked by parental controls.  Your settings may be changed in your account preferences at http://www.worldofwarcraft.com."
    }

}
