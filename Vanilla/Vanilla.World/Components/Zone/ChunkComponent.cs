namespace Vanilla.World.Components.Zone
{
    using System;
    using System.Collections.Generic;
    using Vanilla.Core.Logging;

    public class ChunkComponent : WorldServerComponent
    {
        private List<Chunk> chunks;

        private const float chunkSize = 533.33333f;

        public ChunkComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            chunks = new List<Chunk>();
        }

        public Chunk AddChunk(long zoneID, float x, float y)
        {
            Chunk chunk = new Chunk(zoneID, x, y, chunkSize, chunkSize);

            chunk.AddChild(x, y, chunk.Width / 2, chunk.Height / 2);
            chunk.AddChild(x + chunk.Width / 2, y, chunk.Width / 2, chunk.Height / 2);
            chunk.AddChild(x, y + chunk.Height / 2, chunk.Width / 2, chunk.Height / 2);
            chunk.AddChild(x + chunk.Width / 2, y + chunk.Height / 2, chunk.Width / 2, chunk.Height / 2);

            chunks.Add(chunk);
            Log.Print(LogType.Status, "Created Map: " + chunk.ID);
            return chunk;
        }

        public void RemoveChunk(Chunk chunk)
        {
            chunks.Remove(chunk);
            Log.Print(LogType.Status, "Removed Map: " + chunk.ID);
        }
    }
}
