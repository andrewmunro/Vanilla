using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Tools.DBC.Helper
{
    public class ChrStartingOutfitDBC : CachedDBC<ChrStartingOutfitEntry>
    {
        public ChrStartingOutfitEntry GetCharStartingOutfitString(PCCharCreate character)
        {
            return Find(r => r.Class == character.Class && r.Gender == character.Gender && r.Race == character.Race);
        }

        public ChrStartingOutfitEntry GetCharStartingOutfitString(Character character)
        {
            return Find(r => r.Class == (int)character.Class && r.Gender == (int)character.Gender && r.Race == (int)character.Race);
        }
    }
}
