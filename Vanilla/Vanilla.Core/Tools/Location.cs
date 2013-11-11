namespace Vanilla.Core.Tools
{
    using Microsoft.Xna.Framework;

    public class Location
    {
        public Vector3 Position;

        public int MapID;

        public float Orientation;

        public float X { get { return Position.X; } set { Position.X = value; } }

        public float Y { get { return Position.Y; } set { Position.Y = value; } }

        public float Z { get { return Position.Z; } set { Position.Z = value; } }

        public Location(Vector3 position, float orientation, int mapID)
        {
            this.Position = position;
            this.Orientation = orientation;
            this.MapID = mapID;
        }

        public Location(Vector3 position, float orientation = 0)
        {
            this.Position = position;
            this.Orientation = orientation;
        }

        public Location()
        {
            this.Position = Vector3.Zero;
            this.Orientation = 0;
        }
    }
}
