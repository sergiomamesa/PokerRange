using Poker.Extensions;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Logic
{
    public class FacingRaiseVillainRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public FacingRaiseVillainRule()
        {
            Condition = (list, position) =>
            {
                var raiseList = list.Where(i => i.Action == ActionType.Raise);
                if (raiseList.Count() > 1)
                    if (raiseList.IsOne(i => i.Position == position))
                        return true;

                return false;
            };

            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.FacingRaise,
                Action = list.LastOrDefault(i => i.Position == position).Action,
                Position = list.LastOrDefault(i => i.Position == position).Position
            };
        }
    }
}
