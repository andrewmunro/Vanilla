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
    public class ScriptCompiler : MarshalByRefObject
    {
        private Type type;
        private Object instance;

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
            else
            {
                //Successful Compile
                Log.Print(LogType.Debug, "Script Loaded: " + Name);

                type = results.CompiledAssembly.GetTypes()[0];

                //Instansiate script class.
                try
                {
                    instance = Activator.CreateInstance(type);
                }
                catch (Exception)
                {
                    Log.Print(LogType.Error ,"Error instantiating " + Name);
                    return false;
                }
                
                return true;
            }
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
