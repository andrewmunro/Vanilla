namespace Vanilla.Server
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    using Microsoft.CSharp;

    using Vanilla.Core.Logging;
    using Vanilla.World;
    using Vanilla.World.Components.Chat;
    using Vanilla.World.Tools.Chat;

    public class VanillaPlugin
    {
        public VanillaWorld Core { get { return Program.VanillaWorld; } }

        public virtual void Unload() { }

        protected void AddChatCommand(String commandName, String commandDescription, ChatCommandDelegate method)
        {
            ChatCommandNode node = new ChatCommandNode(commandName, commandDescription);
            node.Method = method.Method;
            node.CommandAttributes = new List<ChatCommandAttribute>();
            Core.ChatCommandEngine.AddNode(node);
        }

        protected void RemoveChatCommand(String commandName)
        {
            Core.ChatCommandEngine.RemoveNode(commandName);
        }
    }

    public class ScriptCompiler
    {
        public VanillaPlugin Plugin { get { return this.instance; } }

        private Type type;
        private VanillaPlugin instance;

        public String Name;

        public bool Compile(string filepath)
        {
            this.Name = Path.GetFileNameWithoutExtension(filepath);
            var code = File.ReadAllText(filepath);

            var codeProvider = new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters
                                 {
                                     GenerateInMemory = true,
                                     GenerateExecutable = false,
                                     IncludeDebugInformation = true
                                 };

            //Add references used in scripts
            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location); //Current application ('using milkshake;')
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            parameters.ReferencedAssemblies.Add("Vanilla.World.dll");
            parameters.ReferencedAssemblies.Add("Vanilla.Core.dll");
            parameters.ReferencedAssemblies.Add("Vanilla.Database.World.dll");
            parameters.ReferencedAssemblies.Add("Vanilla.Database.Character.dll");

            var results = codeProvider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                var error = "Error in script: " + this.Name;

                error = results.Errors.Cast<CompilerError>().Aggregate(error, (current, e) => current + ("\n" + e));

                Log.Print(LogType.Error, error);
                return false;
            }
            //Successful Compile
            Log.Print(LogType.Debug, "Script Loaded: " + this.Name);

            this.type = results.CompiledAssembly.GetTypes()[0];

            //Instansiate script class.
            try
            {
                if (this.type.BaseType == typeof(VanillaPlugin))
                {
                    this.instance = Activator.CreateInstance(this.type) as VanillaPlugin;
                }
                else
                {
                    Log.Print(LogType.Error, "Warning! " + this.Name + " isn't a VanillaPlugin");
                    return false;
                }
                    
            }
            catch (Exception)
            {
                Log.Print(LogType.Error ,"Error instantiating " + this.Name);
                return false;
            }
                
            return true;
        }

        public object RunMethod(string methodName, object[] args = null)
        {
            return this.type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, this.instance, args);
        }

        public object RunStaticMethod(string methodName, object[] args = null)
        {
            return this.type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
        }
    }
}
