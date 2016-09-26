using Poker.Extensions;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public static class SituationRulesGenerator
    {
        public static List<SituationRule> HeroRules()
        {
            var situationRules = new List<SituationRule>();

            situationRules.Add(new SituationRule()
            {
                Condition = (list, position) => list.Where(a => a.Action == ActionType.Raise).Any(p => p.Position == position),
                Result = SituationType.RFIvs3Bet
            });

            situationRules.Add(new SituationRule()
            {
                Condition = (list, postition) => list.None(a => a.Action == ActionType.Raise),
                Result = SituationType.RaiseFirstIn
            });

            situationRules.Add(new SituationRule()
            {
                Condition = (list, position) => list.IsOne(a => a.Action == ActionType.Raise),
                Result = SituationType.FacingRaise
            });

            return situationRules;
        }

        public static List<SituationRule> VillainRules()
        {
            var situationRules = new List<SituationRule>();

            situationRules.Add(new SituationRule()
            {
                Condition = (list, position) => list.IsOne(a => a.Action == ActionType.Raise),
                Result = SituationType.RaiseFirstIn
            });

            situationRules.Add(new SituationRule()
            {
                Condition = (list,position) => list.Where(a => a.Action == ActionType.Raise).Any(p => p.Position == position),
                Result = SituationType.FacingRaise
            });

            return situationRules;
        }
    }
}
