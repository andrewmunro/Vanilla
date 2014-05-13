using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Server.lua
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class LUAFunction : System.Attribute
    {
        public LUAFunction()
        {
        }
    }
}
