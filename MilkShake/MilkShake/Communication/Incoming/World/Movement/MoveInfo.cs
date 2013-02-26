using System.Linq;
using Milkshake.Game.Constants.Game.Update;
using Milkshake.Network;
using Milkshake.Tools;

namespace Milkshake.Communication.Incoming.World.Movement
{
    class MoveInfo : PacketReader
    {
        public MovementFlags moveFlags { get; set; }
        public uint time { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }

        public float swimPitch { get; set; }

        public uint fallTime { get; set; }

        public class Transport
        {
            public float GUID { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; }
            public float R { get; set; }
        }

        public class JumpInfo
        {
            public float velocity { get; set; }
            public float sinAngle { get; set; }
            public float cosAngle { get; set; }
            public float xySpeed { get; set; }
        }

        public float splineUnknown { get; set; }

        public MoveInfo(byte[] data) : base(data)
        {
            moveFlags = (MovementFlags) ReadUInt32();
            time = ReadUInt32();
            X = ReadSingle();
            Y = ReadSingle();
            Z = ReadSingle();
            R = ReadSingle();

            if(moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_ONTRANSPORT)) //On boat/zeplin
            {
                Transport.GUID = ReadUInt32();
                Transport.X = ReadSingle();
                Transport.Y = ReadSingle();
                Transport.Z = ReadSingle();
                Transport.R = ReadSingle();
            }
            if (moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SWIMMING))
            {
                swimPitch = ReadSingle();
            }

            fallTime = ReadUInt32();

            if (moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_FALLING))
            {
                JumpInfo.velocity = ReadSingle();
                JumpInfo.sinAngle = ReadSingle();
                JumpInfo.cosAngle = ReadSingle();
                JumpInfo.xySpeed = ReadSingle();
            }

            if (moveFlags.GetFlags().Contains(MovementFlags.MOVEFLAG_SPLINE_ELEVATION))
            {
                splineUnknown = ReadSingle();
            }
        }
    }
}
