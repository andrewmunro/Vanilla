namespace Vanilla.World.Communication.Chat.Channel
{
    using Vanilla.Core.Network;

    internal class PCChannel : PacketReader
    {
        #region Constructors and Destructors

        public PCChannel(byte[] data)
            : base(data)
        {
            this.ChannelName = ReadCString();
            this.Password = ReadCString();
        }

        #endregion

        #region Public Properties

        public string ChannelName { get; private set; }
        public string Password { get; private set; }

        #endregion
    }
}