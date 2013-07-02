using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Communication;
using Milkshake.Communication.Incoming.Character;
using Milkshake.Net;
using Milkshake.Network;
using Milkshake.Tools;

namespace Milkshake.Game.Handlers
{
    public delegate void ProcessPacketCallback(WorldSession Session, byte[] data);
    public delegate void ProcessPacketCallbackTypes<T>(WorldSession Session, T handler);

    public class DataRouter
    {
        private static Dictionary<byte, ProcessPacketCallback> mCallbacks = new Dictionary<byte, ProcessPacketCallback>();
        
        public static void AddHandler(byte opcode, ProcessPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        public static void AddHandler(AuthOpcodes opcode, ProcessPacketCallback handler) { AddHandler((byte)opcode, handler); }
        public static void AddHandler(Opcodes opcode, ProcessPacketCallback handler) { AddHandler((byte)opcode, handler); }

        public static void AddHandler<T>(byte opcode, ProcessPacketCallbackTypes<T> callback)
        {
            AddHandler(opcode, (session, data) =>
            {
                T generatedHandler = (T)Activator.CreateInstance(typeof(T), data);
                callback(session, generatedHandler);
            });
        }
        public static void AddHandler<T>(AuthOpcodes opcode, ProcessPacketCallbackTypes<T> callback) { AddHandler<T>((byte)opcode, callback); }
        public static void AddHandler<T>(Opcodes opcode, ProcessPacketCallbackTypes<T> callback) { AddHandler<T>((byte)opcode, callback); }


        public static void CallHandler(WorldSession session, byte opcode, byte[] data)
        {
            if (mCallbacks.ContainsKey(opcode))
            {
                mCallbacks[opcode](session, data);
            }
            else
            {
                Log.Print(LogType.Warning, "Missing handler: " + opcode);
            }
        }
    }
}
