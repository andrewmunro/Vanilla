using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.DBC;

namespace Milkshake.Game.Handlers
{
    public class ZoneHandler
    {
        /*
        private static Dictionary<AreaTriggerEntry, BoundingBox> BoundingBoxes;

        public static void Boot()
        {
            BoundingBoxes = new Dictionary<AreaTriggerEntry, BoundingBox>();

            DBC.AreaTrigger.ToList().ForEach(a =>
            {
                BoundingBoxes.Add(a, new BoundingBox(new Vector3(a.X, a.Y, a.Z), new Vector3(a.BoxX, a.BoxY, a.BoxZ)));
            });
        }
        /*
        public static AreaTableEntry GetAreaTableEntry(float x, float y, float z)
        {
            int zoneID = GetAreaTriggerEntry(x, y, z).ID;

            return DBC.AreaTable.First(a => a.ID == zoneID);
        }

        public static AreaTriggerEntry GetAreaTriggerEntry(float x, float y, float z)
        {
            KeyValuePair<AreaTriggerEntry, BoundingBox> bam = BoundingBoxes.First(a => a.Value.Contains(new Vector3(x, y, z)) == ContainmentType.Contains);

            return bam.Value != null ? bam : null;
        }*/
        /*
        public static bool BoundingBox(float x, float y, float z)
        {
            bool result = false;

            foreach (var item in BoundingBoxes.ToList())
            {
                Console.WriteLine(DBC.AreaTable.First(a => a.ID == item.Key.ID).Name);
                if (item.Value.Contains(new Vector3(x, y, z)) == ContainmentType.Contains)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        */
    }
}
