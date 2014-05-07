namespace Vanilla.Core.Tools
{
    using Microsoft.Xna.Framework;

    public class Location
    {
        public Vector3 Position;

        public int MapID;

        public float Orientation;

        public float X { get { return this.Position.X; } set { this.Position.X = value; Moved = true; } }

        public float Y { get { return this.Position.Y; } set { this.Position.Y = value; Moved = true; } }

        public float Z { get { return this.Position.Z; } set { this.Position.Z = value; Moved = true; } }

        //Has the entity moved since last EntityComponent tick.
        public bool Moved;

        public Location(Vector3 position, float orientation, int mapID)
        {
            this.Position = position;
            this.Orientation = orientation;
            this.MapID = mapID;
            this.Moved = false;
        }

        public Location(Vector3 position, float orientation = 0)
        {
            this.Position = position;
            this.Orientation = orientation;
            this.Moved = false;
        }

        public Location()
        {
            this.Position = Vector3.Zero;
            this.Orientation = 0;
            this.Moved = false;
        }
    }
}
