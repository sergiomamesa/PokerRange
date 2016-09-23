using Poker.Extensions;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class SituationRulesGenerator
    {
        private List<SituationRule> SituationRules;

        public List<SituationRule> Create()
        {
            SituationRules = new List<SituationRule>();
            SituationRules.Add(new SituationRule()
            {
                Condition = (list, position) => list.Where(a => a.Action == ActionType.Raise).Any(p => p.Position == position),
                Result = SituationType.RFIvs3Bet
            });
            SituationRules.Add(new SituationRule()
            {
                Condition = (list, postition) => list.None(a => a.Action == ActionType.Raise),
                Result = SituationType.RaiseFirstIn
            });
            SituationRules.Add(new SituationRule()
            {
                Condition = (list, position) => list.IsOne(a => a.Action == ActionType.Raise),
                Result = SituationType.FacingRaise
            });

            return SituationRules;
        }
    }
}
