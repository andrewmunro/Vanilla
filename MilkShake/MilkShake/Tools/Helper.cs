using System;
using System.Linq;
using System.Globalization;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Game.Constants;
using Milkshake.Game.Constants.Character;
using Milkshake.Tools.DBC.Tables;
using Milkshake.Tools.Database.Tables;

namespace Milkshake.Tools
{
    public class Helper
    {
        public static string ByteArrayToHex(byte[] data)
        {
            string packetOutput = "";

            for (int i = 0; i < data.Length; i++)
            {
                packetOutput += data[i].ToString("X2") + " ";
            }

            return packetOutput;
        }

        public static byte[] HexToByteArray(string hex)
        {
            // Cleanup string
            hex = hex.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string NormalizeText(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static int[] CSVStringToIntArray(string csv)
        {
            return csv.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        }

        public static ChrStartingOutfitEntry GetCharStartingOutfitString(PCCharCreate character)
        {
            return DBC.DBC.ChrStartingOutfit.ToList().First(r => r.Class == character.Class && r.Gender == character.Gender && r.Race == character.Race);
        }

        public static ChrStartingOutfitEntry GetCharStartingOutfitString(Character character)
        {
            return DBC.DBC.ChrStartingOutfit.ToList().First(r => r.Class == (int)character.Class && r.Gender == (int)character.Gender && r.Race == (int)character.Race);
        }
    }

    
}
