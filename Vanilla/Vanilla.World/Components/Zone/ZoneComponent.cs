namespace Vanilla.World.Components.Zone
{
    using System.Collections.Generic;
    using Vanilla.Character.Database.Models;
    using Vanilla.Core.Logging;

    public class ZoneComponent : WorldServerComponent
    {
        private Dictionary<long, Zone> zones;

        public ZoneComponent(VanillaWorld vanillaWorld) : base(vanillaWorld)
        {
            zones = new Dictionary<long, Zone>();
        }

        public void AddCharacterToZone(long zoneID, Character character)
        {
            Zone zone = GetZoneByID(zoneID) ?? AddZone(zoneID);
            zone.Characters.Add(character);
        }

        public void AddCharacterToZone(Character character)
        {
            AddCharacterToZone(character.Zone, character);
        }

        public void RemoveCharacterFromZone(long zoneID, Character character)
        {
            GetZoneByID(zoneID).Characters.Remove(character);
        }

        public Zone GetZoneByID(long zoneID)
        {
            return zones[zoneID];
        }

        private Zone AddZone(long zoneID)
        {
            Zone zone = new Zone(zoneID);
            zones.Add(zoneID, zone);
            Log.Print(LogType.Status, "Creating Zone: " + zoneID);
            return zone;
        }

        private void RemoveZone(long zoneID)
        {
            zones.Remove(zoneID);
            Log.Print(LogType.Status, "Removed Zone: " + zoneID);
        }

        //TODO Link up to update.
        public void Update()
        {
            foreach (var zone in zones)
            {
                //TODO Delay for time.
                if (zone.Value.isEmpty)
                {
                    zones.Remove(zone.Key);
                }
            }
        }
    }
}
