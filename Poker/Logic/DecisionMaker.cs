using Poker.Model;
using Poker.Extensions;
using Poker.Model.Enums;
using Poker.Ranges.Parser;
using Poker.Ranges.Reader;
using Ranges.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class DecisionMaker
    {
        private PositionType HeroPosition;
        private List<ActionEvent> ActionEventList;

        public DecisionMaker(List<ActionEvent> actionEventList)
        {
            ActionEventList = actionEventList;
            HeroPosition = (PositionType)(ActionEventList.LastOrDefault().Position + 1);
        }

        private SituationType CalculateSituation()
        {
            if (ActionEventList.Where(a => a.Action == ActionType.Raise).Any(p => p.Position == HeroPosition))
                return SituationType.RFIvs3Bet;

            if (ActionEventList.None(a => a.Action == ActionType.Raise))
                return SituationType.RaiseFirstIn;

            if (ActionEventList.IsOne(a => a.Action == ActionType.Raise))
                return SituationType.FacingRaise;

            throw new NotImplementedException();
        }

        public ActionType Run(Hand heroHand)
        {
            var situation = CalculateSituation();
            var parser = new ActionParser();
            var fileReader = new FileReaderFactory().CreateInstance(situation, HeroPosition);

            var tableRange = fileReader.GetRange(parser);

            return tableRange.GetAction(heroHand);
        }
    }
}
