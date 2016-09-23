using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;

namespace Poker.Logic
{
    public class SituationDecider
    {
        private readonly List<ActionEvent> ActionEventList;
        private readonly PositionType HeroPosition;
        private readonly List<SituationRule> SituationRules;

        public SituationDecider(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;

            SituationRules = new SituationRulesGenerator().Create();
        }
         
        public SituationType CalculateSituation()
        {
            foreach (var rule in SituationRules)
            {
                if (rule.Condition(ActionEventList,HeroPosition))
                    return rule.Result;
            }

            throw new NotImplementedException();
        }
    }
}
