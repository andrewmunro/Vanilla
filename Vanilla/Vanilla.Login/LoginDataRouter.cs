// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginDataRouter.cs" company="">
//   
// </copyright>
// <summary>
//   The process login packet callback.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Vanilla.Login
{
    using System;
    using System.Collections.Generic;

    using Vanilla.Core.Logging;
    using Vanilla.Core.Opcodes;

    /// <summary>
    /// The process login packet callback.
    /// </summary>
    /// <param name="Session">
    /// The session.
    /// </param>
    /// <param name="data">
    /// The data.
    /// </param>
    public delegate void ProcessLoginPacketCallback(LoginSession Session, byte[] data);

    /// <summary>
    /// The process login packet callback types.
    /// </summary>
    /// <param name="Session">
    /// The session.
    /// </param>
    /// <param name="handler">
    /// The handler.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    public delegate void ProcessLoginPacketCallbackTypes<T>(LoginSession Session, T handler);

    /// <summary>
    /// The login data router.
    /// </summary>
    public class LoginDataRouter
    {
        #region Static Fields

        /// <summary>
        /// The m callbacks.
        /// </summary>
        private static readonly Dictionary<LoginOpcodes, ProcessLoginPacketCallback> mCallbacks =
            new Dictionary<LoginOpcodes, ProcessLoginPacketCallback>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add handler.
        /// </summary>
        /// <param name="opcode">
        /// The opcode.
        /// </param>
        /// <param name="handler">
        /// The handler.
        /// </param>
        public static void AddHandler(LoginOpcodes opcode, ProcessLoginPacketCallback handler)
        {
            mCallbacks.Add(opcode, handler);
        }

        /// <summary>
        /// The add handler.
        /// </summary>
        /// <param name="opcode">
        /// The opcode.
        /// </param>
        /// <param name="callback">
        /// The callback.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
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

        /// <summary>
        /// The call handler.
        /// </summary>
        /// <param name="session">
        /// The session.
        /// </param>
        /// <param name="opcode">
        /// The opcode.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
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