using Poker.Model.Enums;
using Ranges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class DecisionMakerResult
    {
        public TableRange HeroRange { get; set; }
        public TableRange VillainRange { get;set; }
        public ActionType HeroAction { get; set; }
    }
}
