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
    public class SituationDecider
    {
        private readonly List<ActionEvent> ActionEventList;
        private readonly PositionType HeroPosition;

        public SituationDecider(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
        }

        public SituationType CalculateSituation()
        {
            if (ActionEventList.Where(a => a.Action == ActionType.Raise).Any(p => p.Position == HeroPosition))
                return SituationType.RFIvs3Bet;

            if (ActionEventList.None(a => a.Action == ActionType.Raise))
                return SituationType.RaiseFirstIn;

            if (ActionEventList.IsOne(a => a.Action == ActionType.Raise))
                return SituationType.FacingRaise;

            throw new NotImplementedException();
        }
    }
}
