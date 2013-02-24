using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Milkshake.Tools
{
    public class Helper
    {
        public static string byteArrayToHex(byte[] data)
        {
            string packetOutput = "";
            byte[] outputData = data;
            for (int i = 0; i < outputData.Length; i++)
            {
                string append = (i == outputData.Length - 1) ? "" : "";

                packetOutput += outputData[i].ToString("X2") + append;
            }

            return packetOutput;
        }

        private static byte[] hexToByteArray(string hex)
        {
            string end = hex.Replace(" ", "").Replace("\n", "");

            return StringToByteArray(end);
        }

        public static byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", "");

            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static string Normalize(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }
    }
}
