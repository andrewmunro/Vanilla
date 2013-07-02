using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Sessions;
using Milkshake.Communication;
using Milkshake.Tools;

namespace Milkshake.Game.Handlers
{
    public delegate void ProcessPacketCallback(LoginSession Session, byte[] data);
    public delegate void ProcessPacketCallbackTypes<T>(LoginSession Session, T handler);

    public class LoginDataRouter
    {
        private static Dictionary<AuthServerOpCode, ProcessPacketCallback> mCallbacks = new Dictionary<AuthServerOpCode, ProcessPacketCallback>();

        public static void AddHandler(AuthServerOpCode opcode, ProcessPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        public static void AddHandler<T>(AuthServerOpCode opcode, ProcessPacketCallbackTypes<T> callback)
        {
            AddHandler(opcode, (session, data) =>
            {
                T generatedHandler = (T)Activator.CreateInstance(typeof(T), data);
                callback(session, generatedHandler);
            });
        }

        public static void CallHandler(LoginSession session, AuthServerOpCode opcode, byte[] data)
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
