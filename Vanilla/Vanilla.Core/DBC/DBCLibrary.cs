using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Core.DBC
{
    public class DBCLibrary
    {
        private Dictionary<string, object> cachedDBCStores = new Dictionary<string, object>();

        public DBCStore<T> GetDBC<T>() where T : struct
        {
            string dbcName = getDBCFileName<T>();

            if (cachedDBCStores.ContainsKey(dbcName))
            {
                return cachedDBCStores[dbcName] as DBCStore<T>;
            }
            else
            {
                DBCStore<T> dbcStore = new DBCStore<T>();
                cachedDBCStores.Add(dbcName, (object)dbcStore);
                return dbcStore;
            }
        }

        public static string getDBCFileName<T>()
        {
            MemberInfo info = typeof(T);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                if (attributes[i] is DBCFileAttribute)
                {
                    return (attributes[i] as DBCFileAttribute).DBCName;
                }
            }

            throw new Exception("Couldn't find DBCFile Attribute");
        }
    }
}
