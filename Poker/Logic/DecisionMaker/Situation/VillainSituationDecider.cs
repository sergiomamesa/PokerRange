using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;

namespace Poker.Logic
{
    public class VillainSituationDecider : SituationDecider
    {
        public VillainSituationDecider(List<ActionEvent> actionEventList, PositionType heroPosition) 
            : base(actionEventList, heroPosition)
        {
        }

        protected override void SetSituationRules()
        {
            SituationRules = new SituationRulesGenerator().VillainRules();
        }
    }
}
