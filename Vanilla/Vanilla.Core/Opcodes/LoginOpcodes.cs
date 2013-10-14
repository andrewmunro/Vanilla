namespace Vanilla.Core.Opcodes
{
    public enum LoginOpcodes : byte
    {
        AUTH_LOGIN_CHALLENGE = 0x00,
        AUTH_LOGIN_PROOF = 0x01,
        AUTH_RECONNECT_CHALLENGE = 0x02,
        AUTH_RECONNECT_PROOF = 0x03,
        REALM_LIST = 0x10,
        XFER_INITIATE = 0x30,
        XFER_DATA = 0x31,
        XFER_ACCEPT = 0x32,
        XFER_RESUME = 0x33,
        XFER_CANCEL = 0x34,

        AUTH_LOGIN_BOT = 0x90,
        //Maximum = 100,

        //Unknown = byte.MaxValue,
    }
}
