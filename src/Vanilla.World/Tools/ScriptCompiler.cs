using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using Microsoft.CSharp;

namespace Milkshake.Tools
{
    public class VanillaPlugin
    {
        public virtual void Unload()
        {

        }
    }

    public class ScriptCompiler
    {
        public VanillaPlugin Plugin { get { return instance; } }

        private Type type;
        private VanillaPlugin instance;

        public String Name;

        public bool Compile(string filepath)
        {
            Name = Path.GetFileNameWithoutExtension(filepath);
            Thread.Sleep(100);
            string code = File.ReadAllText(filepath);

            CSharpCodeProvider codeProvider = new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v3.5" } });
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            parameters.IncludeDebugInformation = true;

            //Add references used in scripts
            parameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location); //Current application ('using milkshake;')
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("System.Data.dll");
            parameters.ReferencedAssemblies.Add("System.Data.DataSetExtensions.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.dll");
            parameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");

            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code);
            if (results.Errors.HasErrors)
            {
                string error = "Error in script: " + Name;

                foreach (CompilerError e in results.Errors)
                {
                    error += "\n" + e;
                }

                Log.Print(LogType.Error, error);
                return false;
            }
            //Successful Compile
            Log.Print(LogType.Debug, "Script Loaded: " + Name);

            type = results.CompiledAssembly.GetTypes()[0];

            //Instansiate script class.
            try
            {
                if (type.BaseType == typeof(VanillaPlugin))
                {
                    instance = Activator.CreateInstance(type) as VanillaPlugin;
                }
                else
                {
                    Log.Print(LogType.Error, "Warning! " + Name + " isn't VanillaPlugin");
                    return false;
                }
                    
            }
            catch (Exception)
            {
                Log.Print(LogType.Error ,"Error instantiating " + Name);
                return false;
            }
                
            return true;
        }

        public object RunMethod(string methodName, object[] args = null)
        {
            return type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, instance, args);
            //return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
        }

        public object RunStaticMethod(string methodName, object[] args = null)
        {
            return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
        }
    }
}
