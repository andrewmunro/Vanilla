using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Milkshake.Tools.DBC
{
    public class CachedDBC<T> where T : new()
    {
        private List<T> _cachedList;

        public CachedDBC(bool autoCache = true)
        {
            if (autoCache) LoadCache();
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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            _cachedList = DBC.SQLite.Table<T>().ToList();

            stopWatch.Stop();

            Log.Print(LogType.Database, "[Cached] Table: " + typeof(T).Name + " - " + stopWatch.ElapsedMilliseconds + "ms " + List.Count);
        }
    }
}
