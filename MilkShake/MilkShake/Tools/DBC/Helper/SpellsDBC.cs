using System;
using System.Collections.Generic;
using Milkshake.Tools.DBC.Tables;

namespace Milkshake.Tools.DBC.Helper
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
