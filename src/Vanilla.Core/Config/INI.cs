using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Milkshake.Tools.Config
{
    static class INI
    {
        private const String FILEPATH = "./config.ini";
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        

        public static void Boot()
        {
            if (!File.Exists(FILEPATH))
            {
                Log.Print(LogType.Warning, "INI file not found! Creating new one!");
                using (FileStream fs = File.Create(FILEPATH));
            }
            
            CheckValues();
            Log.Print(LogType.Server, "INI file initialised");
        }

        private static void CheckValues()
        {
            foreach (var Section in ConfigValues.DEFAULT_VALUES)
            {
                foreach (var Key in Section.Value)
                {
                    //E.G Section.Key = Realm, Key.Key = IP, Key.Value = 127.0.0.1
                    if (GetValue(Section.Key, Key.Key) == "")
                    {
                        SetValue(Section.Key, Key.Key, Key.Value);
                    }
                }
            }
        }

        public static T GetValue<T>(String Section, String Key)
        {
            if (typeof(T) == typeof(int)) return (T)(Object)int.Parse(GetValue(Section, Key));
            Log.Print(LogType.Warning, GetValue(Section, Key));
            if (typeof(T) == typeof(float)) return (T)(Object)float.Parse(GetValue(Section, Key));
            if (typeof(T) == typeof(string)) return (T)(Object)(GetValue(Section, Key));
            return (T)(Object)GetValue(Section, Key);
        }

        public static String GetValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp, 255, FILEPATH);
            return temp.ToString();
        }

        public static void SetValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, FILEPATH);
        }

    }
}
