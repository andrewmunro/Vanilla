namespace Vanilla.World.Components.Zone
{
    using System.Collections.Generic;

    public class Chunk 
    {
        public string ID { get; private set; }

        public long Zone { get; private set; }

        public float X { get; private set; }

        public float Y { get; private set; }

        public float Width { get; private set; }

        public float Height { get; private set; }

        private List<Chunk> Children;

        private Chunk Parent;

        public Chunk(long zone, float x, float y, float width, float height, Chunk parent = null)
        {
            Zone = zone;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Parent = parent;
        }

        public Chunk AddChild(float x, float y, float width, float height)
        {
            if(Children == null) Children = new List<Chunk>();

            Chunk chunk = new Chunk(Zone, x, y, width, height, this);

            Children.Add(chunk);

            return chunk;
        }
    }
}
