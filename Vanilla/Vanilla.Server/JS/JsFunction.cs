using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Server.lua
{
    [AttributeUsage(AttributeTargets.Method)]
    public class JSFunction : Attribute
    {
        public JSFunction()
        {
        }
    }
}
