namespace Vanilla.Core.Tools
{
    using Microsoft.Xna.Framework;

    public class Location
    {
        private Vector3 position;

        public int MapID;

        public float Orientation;

        public float X { get { return this.position.X; } set { this.position.X = value; Moved = true; } }

        public float Y { get { return this.position.Y; } set { this.position.Y = value; Moved = true; } }

        public float Z { get { return this.position.Z; } set { this.position.Z = value; Moved = true; } }

        //Has the entity moved since last EntityComponent tick.
        public bool Moved;

        public Location(Vector3 position, float orientation, int mapID)
        {
            this.position = position;
            this.Orientation = orientation;
            this.MapID = mapID;
            this.Moved = false;
        }

        public Location(Vector3 position, float orientation = 0)
        {
            this.position = position;
            this.Orientation = orientation;
            this.Moved = false;
        }

        public Location()
        {
            this.position = Vector3.Zero;
            this.Orientation = 0;
            this.Moved = false;
        }
    }
}
