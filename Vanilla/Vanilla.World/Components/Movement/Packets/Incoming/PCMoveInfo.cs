namespace Vanilla.World.Components.Movement.Packets.Incoming
{
    using System.Linq;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network.IO;
    using Vanilla.World.Game.Update.Constants;

    public class PCMoveInfo : PacketReader
    {
        public PCMoveInfo(byte[] data)
            : base(data)
        {
            this.moveFlags = (MovementFlags)this.ReadUInt32();
            this.time = this.ReadUInt32();
            this.X = this.ReadSingle();
            this.Y = this.ReadSingle();
            this.Z = this.ReadSingle();
            this.R = this.ReadSingle();

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_ONTRANSPORT))
            {
                // On boat/zeplin
                this.ReadUInt32();
                this.ReadSingle();
                this.ReadSingle();
                this.ReadSingle();
                this.ReadSingle();
            }

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SWIMMING))
            {
                this.swimPitch = this.ReadSingle();
            }

            this.fallTime = this.ReadUInt32();

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_FALLING))
            {
                this.ReadSingle();
                this.ReadSingle();
                this.ReadSingle();
                this.ReadSingle();
            }

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SPLINE_ELEVATION))
            {
                this.splineUnknown = this.ReadSingle();
            }
        }

        public float R { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public uint fallTime { get; set; }
        public MovementFlags moveFlags { get; set; }

        public float splineUnknown { get; set; }
        public float swimPitch { get; set; }
        public uint time { get; set; }

        public class JumpInfo
        {
            public float cosAngle { get; set; }
            public float sinAngle { get; set; }
            public float velocity { get; set; }
            public float xySpeed { get; set; }
        }

        public class Transport
        {
            public float GUID { get; set; }
            public float R { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
        }
    }
}