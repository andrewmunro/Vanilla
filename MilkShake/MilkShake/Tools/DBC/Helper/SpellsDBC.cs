using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return List.FindAll((se) => se.Name.Contains(text));
        }
    }
}
