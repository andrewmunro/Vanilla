namespace Vanilla.World.Components.Zone
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Character.Database.Models;

    public class Zone : IDisposable
    {
        public long ID { get; private set; }

        public List<Character> Characters { get; private set; }

        public bool isEmpty { get { return Characters.Count == 0; } }

        public Zone(long zoneID)
        {
            ID = zoneID;
            Characters = new List<Character>();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Characters = null;
            }
        }
    }
}
