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
    public delegate void ProcessWorldPacketCallback(WorldSession Session, byte[] data);
    public delegate void ProcessWorldPacketCallbackTypes<T>(WorldSession Session, T handler);

    public class WorldDataRouter
    {
        private static Dictionary<Opcodes, ProcessWorldPacketCallback> mCallbacks = new Dictionary<Opcodes, ProcessWorldPacketCallback>();
        
        public static void AddHandler(Opcodes opcode, ProcessWorldPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        public static void AddHandler<T>(Opcodes opcode, ProcessWorldPacketCallbackTypes<T> callback)
        {
            AddHandler(opcode, (session, data) =>
            {
                T generatedHandler = (T)Activator.CreateInstance(typeof(T), data);
                callback(session, generatedHandler);
            });
        }

        public static void CallHandler(WorldSession session, Opcodes opcode, byte[] data)
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
