using System;
using System.Collections.Generic;

namespace Vanilla.Core.Logging
{
    public enum LogType
    {
        None,
        Debug,
        Server,
        Packet,
        Error,
        Warning,
        Database,
        Status,
        Map,
		Script,
        Router
    }

    public class Log
    {
        public static readonly Dictionary<LogType, ConsoleColor> TypeColour = new Dictionary<LogType, ConsoleColor>()
        {
            { LogType.Debug,    ConsoleColor.DarkMagenta },
            { LogType.Server,   ConsoleColor.Green },
            { LogType.Error,    ConsoleColor.Red },
            { LogType.Status,   ConsoleColor.Blue },
            { LogType.Database, ConsoleColor.Magenta },
            { LogType.Map,      ConsoleColor.Cyan },
            { LogType.Packet,   ConsoleColor.Cyan },
            { LogType.Warning,  ConsoleColor.Yellow },
			{ LogType.Script,  ConsoleColor.Cyan },
            { LogType.Router,  ConsoleColor.DarkCyan }
        };

        public static void Print(LogType _type, object _obj)
        {
            Console.ForegroundColor = TypeColour[_type];

            Console.Write("[" + _type.ToString() + "] ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(_obj.ToString());
        }

        public static void Print(string _subject, object _obj, ConsoleColor _colour)
        {
            Console.Write("[" + _subject + "] ");
            Console.ForegroundColor = _colour;
            Console.WriteLine(_obj.ToString());
        }

        public static void Print(object obj)
        {
            Console.WriteLine("[MilkShake] " + obj.ToString());
            //TODO Output to file.log
        }

    }
}
