using System;
using System.Collections.Generic;
using System.IO;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using Microsoft.CSharp;
using Milkshake.Tools;
using Milkshake.Tools.Config;

namespace Milkshake.Game.Managers
{
    public class ScriptManager
    {
        private static List<AppDomain> domains = new List<AppDomain>();
        private static FileSystemWatcher watcher;

        public static void Boot()
        {
            LoadScripts();

            watcher = new FileSystemWatcher(INI.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION));

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*.cs";

            watcher.Changed += ReloadScript;
            watcher.Created += LoadScript;
            watcher.Deleted += UnloadScript;

            watcher.EnableRaisingEvents = true;
        }

        private static void LoadScripts()
        {
            String[] scripts = Directory.GetFiles(INI.GetValue(ConfigSections.DEV, ConfigValues.SCRIPT_LOCATION));
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
            try
            {
                watcher.EnableRaisingEvents = false;

                LoadScript(e.FullPath);
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private static void LoadScript(string scriptPath)
        {
            string scriptName = Path.GetFileNameWithoutExtension(scriptPath);
            AppDomain domain = AppDomain.CreateDomain(scriptName);
            domains.Add(domain);
            ScriptCompiler scriptCompiler = (ScriptCompiler)domain.CreateInstanceFromAndUnwrap(Assembly.GetExecutingAssembly().Location, "Milkshake.Tools.ScriptCompiler");

            scriptCompiler.Compile(scriptPath);
        }

        private static void UnloadScript(object sender, FileSystemEventArgs e)
        {
            try
            {
                watcher.EnableRaisingEvents = false;

                UnloadScript(Path.GetFileNameWithoutExtension(e.FullPath));
                Log.Print(LogType.Debug, "Script Unloaded: " + Path.GetFileNameWithoutExtension(e.FullPath));
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }

        private static void UnloadScript(string scriptName)
        {
            AppDomain domain = domains.First(d => d.FriendlyName == scriptName);
            domains.Remove(domain);
            AppDomain.Unload(domain);
        }
    }
}
