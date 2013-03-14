using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.Config
{
    static class ConfigValues
    {
        public const String LOGIN = "LOGIN";
        public const String WORLD = "WORLD";
        public const String DB = "DB";
        public const String IP = "IP";
        public const String PORT = "PORT";
        public const String MAX_CONNECTIONS = "MAX_CONNECTIONS";

        public const String NAME = "NAME";
        public const String POPULATION = "POPULATION";
        public const String COMMAND_KEY = ".";

        public const String CHARACTER = "CHARACTER";
        public const String DBC = "DBC";

        public static readonly Dictionary<String, Dictionary<String, String>> DEFAULT_VALUES = new Dictionary<string, Dictionary<string, string>>
            {
                {   
                    LOGIN, new Dictionary<String, String>
                    {
                        {IP, "127.0.0.1"},
                        {PORT, "3724"},
                        {MAX_CONNECTIONS, "50"}
                    }
                },
                {
                    WORLD, new Dictionary<String, String>
                    {
                        {IP, "127.0.0.1"},
                        {PORT, "120"},
                        {MAX_CONNECTIONS, "50"},
                        {NAME, "Lucas Smells"},
                        {POPULATION, "3"},
                        {COMMAND_KEY, "."}
                    }
                },
                {
                    DB, new Dictionary<String, String>
                    {
                        {CHARACTER, "database/character.db3"},
                        {WORLD, "database/world.db3"},
                        {DBC, "database/dbc.db3"}
                    }
                },
            };
    }
}
