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
    public class FacingRaiseHeroRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public FacingRaiseHeroRule()
        {
            Condition = (list, position) => list.IsOne(a => a.Action == ActionType.Raise);
            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.FacingRaise,
                Position = position
            };
        }
    }
}
