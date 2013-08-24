using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace Milkshake.Tools
{
    public class ScriptCompiler : MarshalByRefObject
    {
        private Assembly assembly;
        private Type type;

        public void Compile(string filepath)
        {
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
                string error = "Error in script: " + Path.GetFileNameWithoutExtension(filepath);

                foreach (CompilerError e in results.Errors)
                {
                    error += "\n" + e;
                }

                Log.Print(LogType.Error, error);
            }
            else
            {
                //Successful Compile
                Log.Print(LogType.Debug, "Script Loaded: " + Path.GetFileNameWithoutExtension(filepath));

                assembly = results.CompiledAssembly;
                type = assembly.GetTypes()[0];

                //Instansiate script class.
                Activator.CreateInstance(type);
            }
        }

        public object Run(string methodName, object[] args)
        {
            return type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, assembly, args);
        }
    }
}
