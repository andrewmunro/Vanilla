namespace Vanilla.Login
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Core.Logging;
    using Vanilla.Core.Opcodes;

    public delegate void ProcessLoginPacketCallback(LoginSession Session, byte[] data);

    public delegate void ProcessLoginPacketCallbackTypes<T>(LoginSession Session, T handler);

    public class LoginRouter
    {
        #region Static Fields

        private static readonly Dictionary<LoginOpcodes, ProcessLoginPacketCallback> mCallbacks =
            new Dictionary<LoginOpcodes, ProcessLoginPacketCallback>();

        #endregion

        #region Public Methods and Operators

        public static void AddHandler(LoginOpcodes opcode, ProcessLoginPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        public static void AddHandler<T>(LoginOpcodes opcode, ProcessLoginPacketCallbackTypes<T> callback)
        {
            AddHandler(
                opcode, 
                (session, data) =>
                    {
                        var generatedHandler = (T)Activator.CreateInstance(typeof(T), data);
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

        #endregion
    }
}