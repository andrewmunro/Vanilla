using System;
using System.Collections.Generic;
using Vanilla.World.Tools.DBC.Tables;

namespace Vanilla.World.Tools.DBC.Helper
{
    public class SpellsDBC : CachedDBC<SpellEntry>
    {
        public SpellEntry GetSpellByID(int ID)
        {
            return List.Find((se) => se.ID == ID);
        }

        public List<SpellEntry> GetSpellsBySchool(int school)
        {
            return List.FindAll((se) => se.School == school);
        }

        public List<SpellEntry> GetSpellsNameContain(string text)
        {
            return List.FindAll((se) => se.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
