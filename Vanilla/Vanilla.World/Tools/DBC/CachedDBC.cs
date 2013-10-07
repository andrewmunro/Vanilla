using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Vanilla.World.Tools.DBC
{
    public class CachedDBC<T> where T : new()
    {   
        private List<T> _cachedList;

        public CachedDBC(bool autoCache = true)
        {
            if (autoCache)
            {
                DBC.QueuedCachedDBC.Add(typeof(T).Name);

                LoadCache();
            }
        }

        public T Find(Predicate<T> match)
        {
            return List.Find(match);
        }

        public List<T> List
        {
            get
            {
                if (_cachedList == null) LoadCache();

                return _cachedList;
            }
        }

        private void LoadCache()
        {
            BackgroundWorker bw = new BackgroundWorker();
            Stopwatch stopWatch = new Stopwatch();

            bw.DoWork += (sender, args) =>
            {
                stopWatch.Start();
                _cachedList = DBC.SQLite.Table<T>().ToList();

            };

            bw.RunWorkerCompleted += (sender, args) =>
            {
                stopWatch.Stop();
                Log.Print(LogType.Database, "[Cached] Table: " + typeof(T).Name + " - " + stopWatch.ElapsedMilliseconds + "ms " + List.Count);

                DBC.QueuedCachedDBC.Remove(typeof(T).Name);
            };

            bw.RunWorkerAsync();
        }
    }
}
