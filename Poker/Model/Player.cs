using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Model
{
    public class Player
    {
        //public bool IsDealer { get; private set; }
        //public bool IsSmallBlind { get; private set; }
        //public bool IsBigBlind { get; private set; }
        public Hand Hand { get; set; }
        public bool IsHero = false;
    }
}
