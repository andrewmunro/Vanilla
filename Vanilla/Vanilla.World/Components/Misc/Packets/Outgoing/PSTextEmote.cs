namespace Vanilla.World.Components.Misc.Packets.Outgoing
{
    using System.Text;

    using Vanilla.Core.Network.Packet;
    using Vanilla.Core.Opcodes;

    public class PSTextEmote : WorldPacket
    {
        public PSTextEmote(int GUID, int emoteID, int textID, string targetName = null)
            : base(WorldOpcodes.SMSG_TEXT_EMOTE)
        {
            this.Write((ulong)GUID);
            this.Write((uint)textID);
            this.Write((uint)emoteID);

            if (targetName != null)
            {
                this.Write((uint)targetName.Length);
                this.Write(Encoding.UTF8.GetBytes(targetName));
            }
            else
            {
                this.Write((uint)1);
                this.Write((byte)0);
            }
        }
    }
}