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

        public override void SetSituationRules()
        {
            SituationRules = SituationRulesGenerator.VillainRules();
        }

        public override SituationType CalculateSituation()
        {
            foreach (var rule in SituationRules)
            {
                if (rule.Condition(ActionEventList, HeroPosition))
                    return rule.Result;
            }

            throw new NotImplementedException();
        }
    }
}
