using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class SituationDeciderResult
    {
        public SituationType Situation { get; set; }
        public ActionType Action { get; set; }
        public PositionType Position { get; set; }
    }
}
