namespace Vanilla.World.Communication.Incoming.World.Player
{
    public class PCAreaTrigger : PacketReader
    {
        #region Constructors and Destructors

        public PCAreaTrigger(byte[] data)
            : base(data)
        {
            this.TriggerID = ReadUInt32();
        }

        #endregion

        #region Public Properties

        public uint TriggerID { get; private set; }

        #endregion
    }
}