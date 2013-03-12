using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Net;
using Milkshake.Tools.DBC.Tables;

namespace Milkshake.Tools.Chat.Commands
{
    public class SpellCommands
    {
        [ChatCommand("lookup", "Takes a spellName string and returns a spellID int.")]
        public static void Lookup(WorldSession session, string[] args)
        {
            string spellName = args[1];

            List<SpellEntry> matchingSpells = DBC.DBC.Spells.Where(s => s.Name.Contains(spellName)).ToList();

            matchingSpells.ForEach(s => session.sendMessage("[" + s.ID + "] " + s.Name));
        }
    }
}
