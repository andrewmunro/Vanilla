using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vanilla.Server.lua;
using Vanilla.World;

namespace Vanilla.Server
{
    public class LuaManager
    {
        private FileSystemWatcher watcher;
        public JavascriptContext Script;

        public LuaManager(VanillaWorld world)
        {
            /*watcher = new FileSystemWatcher("scripts")
            {
                NotifyFilter = NotifyFilters.LastAccess |
                               NotifyFilters.LastWrite |
                               NotifyFilters.FileName |
                               NotifyFilters.DirectoryName,
                Filter = "*.lua"
            };

            //watcher.Changed += ReloadScript;
            //watcher.Created += LoadScript;
            //watcher.Renamed += LoadScript;
            //watcher.Deleted += UnloadScript;

            watcher.EnableRaisingEvents = true;*/

            Script = new JavascriptContext();
            
            

            //AddFunctions(typeof(DefaultScriptFunctions));
            Script.SetParameter("debug", new Debug());
            Script.Run(File.ReadAllText("Scripts//test.js"));
        }

        

        private void AddFunctions(Type classType)
        {
            MethodInfo[] scriptFunctions = classType.GetMethods();

            for (int index = 0; index < scriptFunctions.Length; index++)
            {
                bool isLuaFunction = (Attribute.IsDefined(scriptFunctions[index], typeof(LUAFunction)));
                if (isLuaFunction)
                {
                    AddGlobalFunction(classType, scriptFunctions[index].Name);

                    Console.WriteLine("Adding Function: " + scriptFunctions[index].Name);
                }
            }
        }

        private void AddGlobalFunction(Type _Type, string _LocalName, string _LUAName = "_NameClone")
        {
            if (_LUAName == "_NameClone")
                _LUAName = _LocalName;

            try
            {
                MethodInfo _MethodInfo = _Type.GetMethod(_LocalName);

                Script.SetParameter(_LUAName, Delegate.CreateDelegate(_Type, _MethodInfo));
            }
            catch (Exception e)
            {
                Console.WriteLine("AddGlobalFunction - Failed!" +
                                                          "\n\tType:" + _Type.Name +
                                                          "\n\tLocal:" + _LocalName +
                                                          "\n\tLuaName:" + _LUAName);
            }
        }
    }
}
