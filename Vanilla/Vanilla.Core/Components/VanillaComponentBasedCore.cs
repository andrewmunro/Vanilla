namespace Vanilla.Core.Components
{
    using System.Collections.Generic;

    public class VanillaComponentBasedCore<T> : VanillaCore 
    {
        public List<T> Components;

        public VanillaComponentBasedCore()
        {
            Components = new List<T>();
        }
    }
}
