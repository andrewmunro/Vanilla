namespace Vanilla.World.Components.Zone
{
    using System;
    using System.Collections.Generic;

    using Database.Character.Models;

    public class Zone 
    {
        public long ID { get; private set; }

        public List<Character> Characters { get; private set; }

        public bool isEmpty { get { return Characters.Count == 0; } }

        public Zone(long zoneID)
        {
            ID = zoneID;
            Characters = new List<Character>();
        }
    }
}
