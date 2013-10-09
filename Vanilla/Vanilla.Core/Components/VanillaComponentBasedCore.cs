using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanilla.Core.Components
{
    public class VanillaComponentBasedCore<T> : VanillaCore 
    {
        public List<T> Components;

        public VanillaComponentBasedCore()
        {
            Components = new List<T>();
        }
    }
}
