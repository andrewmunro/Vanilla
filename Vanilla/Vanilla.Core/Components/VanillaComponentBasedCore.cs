namespace Vanilla.Core.Components
{
    using System.Collections.Generic;
    using System.Linq;

    public class VanillaComponentBasedCore<T> : VanillaCore 
    {
        public List<T> Components;

        public VanillaComponentBasedCore()
        {
            Components = new List<T>();
        }

        public T GetComponent<T>()
        {
            return Components.OfType<T>().Single();
        }
    }
}
