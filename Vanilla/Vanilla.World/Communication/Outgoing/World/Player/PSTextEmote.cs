namespace Vanilla.World.Communication.Outgoing.World.Player
{
    #region

    using System.Text;

    using Vanilla.Core.Network;
    using Vanilla.Core.Opcodes;

    #endregion

    public class PSTextEmote : ServerPacket
    {
        #region Constructors and Destructors

        public PSTextEmote(int GUID, int emoteID, int textID, string targetName = null)
            : base(WorldOpcodes.SMSG_TEXT_EMOTE)
        {
            Write((ulong)GUID);
            Write((uint)textID);
            Write((uint)emoteID);

            if (targetName != null)
            {
                Write((uint)targetName.Length);
                Write(Encoding.UTF8.GetBytes(targetName));
            }
            else
            {
                Write((uint)1);
                Write((byte)0);
            }
        }

        #endregion
    }
}