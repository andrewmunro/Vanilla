namespace Vanilla.World.Components.ActionBar.Packets.Incoming
{
    using System;

    using Vanilla.Core.Network.IO;
    using Vanilla.World.Components.ActionBar.Constants;

    public sealed class PCSetActionButton : PacketReader
    {
        public byte Button { get; private set; }
        public uint Action { get; private set; }
        public ActionButtonType Type { get; private set; }

        public PCSetActionButton(byte[] data) : base(data)
        {
            Button = ReadByte();
            var packedData = ReadUInt32();
            Action = packedData & 0x00FFFFFF;
            Type = (ActionButtonType)((packedData & 0xFF000000) >> 24);
        }
    }
}
