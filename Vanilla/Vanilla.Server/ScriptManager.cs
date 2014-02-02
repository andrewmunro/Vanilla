namespace Vanilla.Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Vanilla.Core.Config;
    using Vanilla.Core.Logging;

    public class ScriptManager
    {
        private readonly List<ScriptCompiler> scripts = new List<ScriptCompiler>();
        private FileSystemWatcher watcher;

        private string ScriptLocation { get { return Config.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION); } }

        public ScriptManager()
        {
            LoadScripts();

            watcher = new FileSystemWatcher(Config.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION))
                          {
                              NotifyFilter =
                                  NotifyFilters
                                      .LastAccess
                                  | NotifyFilters
                                        .LastWrite
                                  | NotifyFilters
                                        .FileName
                                  | NotifyFilters
                                        .DirectoryName,
                              Filter =
                                  "*.cs"
                          };

            watcher.Changed += ReloadScript;
            watcher.Created += LoadScript;
            watcher.Renamed += LoadScript;
            watcher.Deleted += UnloadScript;

            watcher.EnableRaisingEvents = true;
        }

        private void LoadScripts()
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

        private void ReloadScript(object source, FileSystemEventArgs e)
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

        private void LoadScript(object sender, FileSystemEventArgs e)
        {
            LoadScript(e.FullPath);
        }

        private void LoadScript(string scriptPath)
        {
            ScriptCompiler script = new ScriptCompiler();
            if(script.Compile(scriptPath)) scripts.Add(script);
        }

        private void UnloadScript(object sender, FileSystemEventArgs e)
        {
            UnloadScript(Path.GetFileNameWithoutExtension(e.FullPath));
        }

        private void UnloadScript(string scriptName)
        {
            ScriptCompiler script = scripts.FirstOrDefault(s => s.Name == scriptName);

            if (script != null)
            {
                scripts.Remove(script);
                
                script.Plugin.Unload();

                Log.Print(LogType.Script, "Script Unloaded: " + scriptName);
            }
        }
    }
}
