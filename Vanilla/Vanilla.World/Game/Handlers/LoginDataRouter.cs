using System;
using System.Collections.Generic;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Tools;

namespace Vanilla.World.Game.Handlers
{
    public delegate void ProcessLoginPacketCallback(LoginSession Session, byte[] data);
    public delegate void ProcessLoginPacketCallbackTypes<T>(LoginSession Session, T handler);

    public class LoginDataRouter
    {
        private static Dictionary<LoginOpcodes, ProcessLoginPacketCallback> mCallbacks = new Dictionary<LoginOpcodes, ProcessLoginPacketCallback>();

        public static void AddHandler(LoginOpcodes opcode, ProcessLoginPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        public static void AddHandler<T>(LoginOpcodes opcode, ProcessLoginPacketCallbackTypes<T> callback)
        {
            AddHandler(opcode, (session, data) =>
            {
                T generatedHandler = (T)Activator.CreateInstance(typeof(T), data);
                callback(session, generatedHandler);
            });
        }

        public static void CallHandler(LoginSession session, LoginOpcodes opcode, byte[] data)
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
