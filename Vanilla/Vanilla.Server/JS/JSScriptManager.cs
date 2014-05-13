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
            Script.SetParameter("debug", new Debug());
            Script.Run(File.ReadAllText("Scripts//test.js"));
        }
    }
}
