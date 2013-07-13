using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Tools.DBC.Tables
{
    public class EmotesEntry
    {
        public uint ID { get; set; }
        public String Name { get; set; }
        public int AnimationID { get; set; }
        public int Flags { get; set; }
        public int EmoteType { get; set; }
        public int UnitStandState { get; set; }
        public int SoundID { get; set; }
    }
}
