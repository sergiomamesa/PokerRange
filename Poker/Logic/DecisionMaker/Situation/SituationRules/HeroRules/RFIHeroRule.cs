using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model;
using Poker.Model.Enums;
using Poker.Extensions;

namespace Poker.Logic
{
    public class RFIHeroRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public RFIHeroRule()
        {
            Condition = (list, postition) => list.None(a => a.Action == ActionType.Raise);
            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.RaiseFirstIn,
                Position = position
            };
        }
    }
}
