using Poker.Extensions;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class RFIvs3BetHeroRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public RFIvs3BetHeroRule()
        {
            Condition = (list, position) =>
            {
                var listRaises = list.Where(a => a.Action == ActionType.Raise);
                if (listRaises.Count() != 2)
                    return false;

                if (listRaises.First().Position == position)
                    return true;

                return false;
            };
            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.RFIvs3Bet,
                Position = position
            };
        }
    }
}
