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
        private readonly List<ActionEvent> ActionEventList;
        private readonly PositionType HeroPosition; 

        public DecisionMaker(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
        }

        private PositionType CalculateVillainPosition()
        {
            throw new NotImplementedException();
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
            var fileReaderFactoryParams = new FileReaderFactoryParams()
            {
                Situation = CalculateSituation(),
                HeroPosition = HeroPosition,
                VillainPosition = CalculateVillainPosition()
            };

            var fileReader = new FileReaderFactory().CreateInstance(fileReaderFactoryParams);
            var tableRange = fileReader.GetRange(new ActionParser());

            return tableRange.GetAction(heroHand);
        }
    }
}
