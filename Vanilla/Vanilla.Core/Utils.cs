namespace Vanilla.Core
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class Utils
    {
        public static string ByteArrayToHex(byte[] data)
        {
            string packetOutput = string.Empty;

            for (int i = 0; i < data.Length; i++)
            {
                packetOutput += data[i].ToString("X2") + " ";
            }

            return packetOutput;
        }

        public static byte[] HexToByteArray(string hex)
        {
            // Cleanup string
            hex = hex.Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty);

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
            string[] vals = csv.Split(',');

            return csv != "" ? csv.Split(',').Select(n => Convert.ToInt32(n)).ToArray() : null;
        }

        public static float Distance(float aX, float aY, float bX, float bY)
        {
            return (float)Math.Sqrt(Math.Pow(aX - bX, 2) + Math.Pow(aY - bY, 2));
        }

    }

    
}
