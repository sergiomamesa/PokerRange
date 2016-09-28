using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;

namespace Poker.Logic
{
    public class NoVillainRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public NoVillainRule()
        {
            Condition = (list, position) => true;
            Result = (list, position) => new SituationDeciderResult();
        }
    }
}
