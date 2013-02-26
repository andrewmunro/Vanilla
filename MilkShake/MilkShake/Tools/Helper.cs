using System;
using System.Linq;
using System.Globalization;

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
    }

    
}
