namespace Vanilla.World.Communication.Incoming.World.Movement
{
    #region

    using System.Linq;

    using Vanilla.Core.Extensions;
    using Vanilla.Core.Network;
    using Vanilla.World.Game.Constants.Game.Update;

    #endregion

    public class PCMoveInfo : PacketReader
    {
        #region Constructors and Destructors

        public PCMoveInfo(byte[] data)
            : base(data)
        {
            this.moveFlags = (MovementFlags)ReadUInt32();
            this.time = ReadUInt32();
            this.X = ReadSingle();
            this.Y = ReadSingle();
            this.Z = ReadSingle();
            this.R = ReadSingle();

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_ONTRANSPORT))
            {
                // On boat/zeplin
                ReadUInt32();
                ReadSingle();
                ReadSingle();
                ReadSingle();
                ReadSingle();
            }

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SWIMMING))
            {
                this.swimPitch = ReadSingle();
            }

            this.fallTime = ReadUInt32();

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_FALLING))
            {
                ReadSingle();
                ReadSingle();
                ReadSingle();
                ReadSingle();
            }

            if (this.moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SPLINE_ELEVATION))
            {
                this.splineUnknown = ReadSingle();
            }
        }

        #endregion

        #region Public Properties

        public float R { get; set; }

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public uint fallTime { get; set; }
        public MovementFlags moveFlags { get; set; }

        public float splineUnknown { get; set; }
        public float swimPitch { get; set; }
        public uint time { get; set; }

        #endregion

        public class JumpInfo
        {
            #region Public Properties

            public float cosAngle { get; set; }
            public float sinAngle { get; set; }
            public float velocity { get; set; }
            public float xySpeed { get; set; }

            #endregion
        }

        public class Transport
        {
            #region Public Properties

            public float GUID { get; set; }
            public float R { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }

            #endregion
        }
    }
}