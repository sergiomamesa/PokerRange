using Poker.Extensions;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Logic
{
    public class RFIvs3BetVillainRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public RFIvs3BetVillainRule()
        {
            Condition = (list, position) =>
            {
                var raiseList = list.Where(i => i.Action == ActionType.Raise);
                if (raiseList.Count() != 3)
                    return false;

                return raiseList.IsOne(i => i.Position == position);
            };

            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.RFIvs3Bet,
                Action = list.LastOrDefault(i => i.Position == position).Action,
                Position = list.LastOrDefault(i => i.Position == position).Position
            };
        }
    }
}
