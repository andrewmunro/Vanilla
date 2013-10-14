using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vanilla.World.Tools;

namespace Vanilla.World.Game.Managers
{
    public class ScriptManager
    {
        private static List<ScriptCompiler> scripts = new List<ScriptCompiler>();
        private static FileSystemWatcher watcher;

        public static void Boot()
        {
            LoadScripts();

            watcher = new FileSystemWatcher(INI.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION));

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.cs";

            watcher.Changed += ReloadScript;
            watcher.Created += LoadScript;
            watcher.Renamed += LoadScript;
            watcher.Deleted += UnloadScript;

            watcher.EnableRaisingEvents = true;
        }

        private static void LoadScripts()
        {
			if (!Directory.Exists(ScriptLocation))
			{
				Log.Print(LogType.Script, "Script location (" + ScriptLocation + ") dosn't exist. Creating...");

				Directory.CreateDirectory(ScriptLocation);
			}

            String[] scripts = Directory.GetFiles(ScriptLocation);

            foreach (String script in scripts)
            {
                LoadScript(script);
            }
        }

        private static void ReloadScript(object source, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;

                string scriptName = Path.GetFileNameWithoutExtension(e.FullPath);
                UnloadScript(scriptName);
                LoadScript(e.FullPath);
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private static void LoadScript(object sender, FileSystemEventArgs e)
        {
            LoadScript(e.FullPath);
        }

        private static void LoadScript(string scriptPath)
        {
            ScriptCompiler script = new ScriptCompiler();
            if(script.Compile(scriptPath)) scripts.Add(script);
        }

        private static void UnloadScript(object sender, FileSystemEventArgs e)
        {
            UnloadScript(Path.GetFileNameWithoutExtension(e.FullPath));
        }

        private static void UnloadScript(string scriptName)
        {
            ScriptCompiler script = scripts.FirstOrDefault(s => s.Name == scriptName);

            if (script != null)
            {
                scripts.Remove(script);
                
				script.Plugin.Unload();

                Log.Print(LogType.Script, "Script Unloaded: " + scriptName);
            }
        }

		public static string ScriptLocation
		{
			get { return INI.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION); }
		}
    }
}
