using System;
using System.Collections.Generic;

namespace Vanilla.Core.Config
{
    public static class ConfigSections
    {
        public const String LOGIN = "LOGIN";
        public const String WORLD = "WORLD";
        public const String DEV = "DEV";
        public const String DB = "DB";
    }

    public static class ConfigValues
    {
        public const String IP = "IP";
        public const String PORT = "PORT";
        public const String MAX_CONNECTIONS = "MAX_CONNECTIONS";

        public const String NAME = "NAME";
        public const String POPULATION = "POPULATION";
        public const String COMMAND_KEY = ".";

        public const String CHARACTER = "CHARACTER";
        public const String DBC = "DBC";

        public const String DBC_LOCATION = "DBC_LOCATION";
        public const String SCRIPT_LOCATION = "SCRIPT_LOCATION";

        public static readonly Dictionary<String, Dictionary<String, String>> DEFAULT_VALUES = new Dictionary<string, Dictionary<string, string>>
            {
                {   
                    ConfigSections.LOGIN, new Dictionary<String, String>
                    {
                        {IP, "127.0.0.1"},
                        {PORT, "3724"},
                        {MAX_CONNECTIONS, "50"}
                    }
                },
                {
                    ConfigSections.WORLD, new Dictionary<String, String>
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
                    ConfigSections.DB, new Dictionary<String, String>
                    {
                        {CHARACTER, "database/character.db3"},
                        {ConfigSections.WORLD, "database/world.db3"},
                        {DBC, "database/dbc.db3"}
                    }
                },
                {
                    ConfigSections.DEV, new Dictionary<String, String>
                    {
                        {DBC_LOCATION, @"dbc"},
                        {SCRIPT_LOCATION, @"Scripts"},
                    }
                },
            };
    }
}
