using System;
using System.Globalization;
using System.Linq;

namespace Vanilla.World.Tools
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

        public static string byteArrayToHex(byte[] data, int legnth)
        {
            string packetOutput = "";
            byte[] outputData = data;
            for (int i = 0; i < legnth; i++)
            {
                string append = (i == legnth - 1) ? "" : "-";

                packetOutput += outputData[i].ToString("X2") + append;
            }

            return packetOutput;
        }

        public static float Distance(float aX, float aY, float bX, float bY)
        {
            return (float)Math.Sqrt(Math.Pow(aX - bX, 2) + Math.Pow(aY - bY, 2));
        }

    }

    
}
