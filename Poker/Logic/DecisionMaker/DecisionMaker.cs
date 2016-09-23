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

        public ActionType Run(Hand heroHand)
        {
            var fileReaderFactoryParams = new FileReaderFactoryParams()
            {
                Situation = new SituationDecider(ActionEventList, HeroPosition).CalculateSituation(),
                HeroPosition = HeroPosition,
                VillainPosition = new VillainDecider(ActionEventList, HeroPosition).CalculateVillainPosition()
            };

            var fileReader = new FileReaderFactory().CreateInstance(fileReaderFactoryParams);
            var tableRange = fileReader.GetRange(new ActionParser());

            return tableRange.GetAction(heroHand);
        }
    }
}
