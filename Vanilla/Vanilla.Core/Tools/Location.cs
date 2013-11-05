namespace Vanilla.Core.Tools
{
    using Microsoft.Xna.Framework;

    public struct Location
    {
        public Vector3 Position;

        public float X { get { return Position.X; } }

        public float Y { get { return Position.Y; } }

        public float Z { get { return Position.Z; } }

        public float Orientation;

        public Location(Vector3 position, float orientation)
        {
            this.Position = position;
            this.Orientation = orientation;
        }
    }
}
