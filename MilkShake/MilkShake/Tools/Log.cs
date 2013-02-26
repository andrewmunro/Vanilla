using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools
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
        LuaManager,
        Lua
    }

    public class Log
    {
        public static void Print(LogType _type, object _obj)
        {
            switch (_type)
            {
                case LogType.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case LogType.Server:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                    break;
                case LogType.Status:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case LogType.Database:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case LogType.Map:
                case LogType.Packet:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.Lua:
                case LogType.LuaManager:
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

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
        }

    }
}
