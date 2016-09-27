using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model;
using Poker.Model.Enums;

namespace Poker.Logic
{
    public abstract class SituationDecider : ISituationDecider
    {
        public List<ActionEvent> ActionEventList { get; set; }
        public PositionType HeroPosition { get; set; }
        public List<SituationRule> SituationRules { get; set; }

        public SituationDecider(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
        }

        public abstract void SetSituationRules();

        public virtual SituationType CalculateSituation()
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
