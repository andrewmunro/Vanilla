using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Entitys;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Tools.Database.Helpers
{
    class DBCreatures
    {
        private static List<CreatureEntry> CreatureCache;
        public static List<CreatureEntry> Creatures
        {
            get
            {
                if (CreatureCache == null) CreatureCache = DB.World.Table<CreatureEntry>().ToList();

                return CreatureCache;
            }
        }

        public static List<CreatureEntry> GetCreatures(PlayerEntity entity, float Radius)
        {
            return Creatures.FindAll((cr) => entity.Character.MapID == cr.map && Helper.Distance(entity, cr.position_x, cr.position_y, cr.position_z) < Radius);
        }

        public static CreatureTemplateEntry GetCreatureTemplate(uint Entry)
        {
            return DBC.DBC.CreatureTemplates.Find((crt) => crt.entry == Entry);
        }
    }
}
