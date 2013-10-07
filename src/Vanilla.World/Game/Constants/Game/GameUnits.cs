using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milkshake.Game.Constants.Game
{
    public enum GameUnits : int
    {
        SECOND=1, MINUTE=60, HOUR = 60*60, DAY=24*60*60, SUNRISE=24*60*60/4, SUNSET=24*60*60*3/4, MIDNIGHT=0, METER=1, KILOMETER=1000
    };
}
