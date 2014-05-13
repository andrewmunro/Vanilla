using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Server.lua
{
    public class Debug
    {
        public void trace(object _object)
        {
            if (_object == null) _object = "Null";
            Console.WriteLine("[LUA] " + _object.ToString());
        }
    }
}
