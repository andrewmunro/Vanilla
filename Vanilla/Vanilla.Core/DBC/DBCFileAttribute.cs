using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Core.DBC
{
    public class DBCFileAttribute : Attribute
    {
        public string DBCName { get; protected set; }
        public DBCFileAttribute(string dbcName)
        {
            DBCName = dbcName;
        }
    }
}
