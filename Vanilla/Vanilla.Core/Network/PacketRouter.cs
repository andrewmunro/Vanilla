namespace Vanilla.Core.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Vanilla.Core.Logging;

    public delegate void ProcessLoginPacketCallback<in TSession, in TReader>(TSession session, TReader reader) where TSession : Session where TReader : BinaryReader;
    
    public delegate void ProcessLoginPacketCallbackTypes<in TSession, in TReader>(TSession session, TReader customReader) where TSession : Session where TReader : BinaryReader;

    public abstract class PacketRouter<TOpcode, TSession, TReader> where TSession : Session where TReader : BinaryReader
    {
        protected PacketRouter()
        {
            CallBacks = new Dictionary<TOpcode, ProcessLoginPacketCallback<TSession, TReader>>();
        }

        public Dictionary<TOpcode, ProcessLoginPacketCallback<TSession, TReader>> CallBacks { get; private set; }

        public void AddHandler(TOpcode opcode, ProcessLoginPacketCallback<TSession, TReader> handler)
        {
            Log.Print(LogType.Router, "Added handler for " + opcode);

            CallBacks.Add(opcode, handler);
        }

        public void AddHandler<TCustomReader>(TOpcode opcode, ProcessLoginPacketCallbackTypes<TSession, TCustomReader> callback) where TCustomReader : BinaryReader
        {
            AddHandler(opcode, (session, data) =>
            {
                var generatedHandler = (TCustomReader)Activator.CreateInstance(typeof(TCustomReader), (data.BaseStream as MemoryStream).ToArray());

                callback(session, generatedHandler);
            });
        }

        public void CallHandler(TSession session, byte[] data)
        {
            TReader packetReader = (TReader)Activator.CreateInstance(typeof(TReader), data);
            TOpcode opcode = FetchOpcode(packetReader);

            Log.Print(LogType.Router, "Calling " + opcode + " Handler");

            if (CallBacks.ContainsKey(opcode))
            {
                CallBacks[opcode](session, packetReader);
            }
            else
            {
                Log.Print(LogType.Warning, "Missing handler: " + opcode);
            }
        }

        public abstract TOpcode FetchOpcode(TReader packet);
    }
}
