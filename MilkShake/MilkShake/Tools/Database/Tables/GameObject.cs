using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Milkshake.Tools.Database.Tables
{
    public class GameObject
    {
        public int GUID { get; set; }
        public int ID { get; set; }

        public int Map { get; set; }
        public float X { get; set; }
        public float Y{ get; set; }
        public float Z { get; set; }
        public float R { get; set; }
    }
}
