using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model;
using Poker.Model.Enums;

namespace Poker.Logic
{
    public abstract class SituationDecider
    {
        private List<ActionEvent> ActionEventList { get; set; }
        private PositionType Position { get; set; }
        protected List<ISituationRule> SituationRules { get; set; }

        public SituationDecider(List<ActionEvent> actionEventList, PositionType position)
        {
            ActionEventList = actionEventList;
            Position = position;
        }

        protected abstract void SetSituationRules();

        public SituationDeciderResult CalculateSituation()
        {
            SetSituationRules();

            foreach (var rule in SituationRules)
            {
                if (rule.Condition(ActionEventList, Position))
                    return rule.Result(ActionEventList, Position);
            }

            throw new Exception("None of the rules match this situation");
        }
    }
}
