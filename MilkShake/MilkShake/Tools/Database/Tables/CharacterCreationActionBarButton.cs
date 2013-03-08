using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Game.Constants;

namespace Milkshake.Tools.Database.Tables
{
    class CharacterCreationActionBarButton
    {
        public RaceID Race { get; set; }
        public ClassID Class { get; set; }
        public int Button { get; set; }
        public int Action { get; set; }
        public int Type { get; set; }
    }
}
