using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Net;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Game.Entitys;

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

        [ChatCommand("tp", "Teleport to player")]
        public static void Teleport(WorldSession session, string[] args)
        {
            string playerName = args[0].ToLower();

            PlayerEntity player = WorldServer.Sessions.Find(s => s.Character.Name.ToLower() == playerName).Entity;

            if(player != null)
            {
                session.Teleport(player.Character.MapID, player.X, player.Y, player.Z); 
            }
            else
            {
                session.sendMessage("Cannot find player");
            }
        }
    }
}
