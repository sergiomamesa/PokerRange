using Poker.Model;
using Poker.Model.Enums;
using Poker.Ranges.Parser;
using Poker.Ranges.Reader;
using Ranges;
using System.Collections.Generic;

namespace Poker.Logic
{
    public class DecisionMaker
    {
        private readonly List<ActionEvent> ActionEventList;
        private readonly PositionType HeroPosition;

        public TableRange HeroRange { get; private set; }
        public TableRange VillainRange { get; private set; }
        public ActionType HeroAction { get; private set; }

        public DecisionMaker(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
        }

        private void HeroResult(Hand hand)
        {
            var fileReaderFactoryParams = new FileReaderFactoryParams()
            {
                Situation = new HeroSituationDecider(ActionEventList, HeroPosition).CalculateSituation(),
                HeroPosition = HeroPosition,
                VillainPosition = new VillainPositionDecider(ActionEventList, HeroPosition).CalculateVillainPosition()
            };

            var fileReader = new FileReaderFactory().CreateInstance(fileReaderFactoryParams);
            HeroRange = fileReader.GetRange(new ActionParser());
            HeroAction = HeroRange.GetAction(hand);
        }

        private void VillainResult()
        {
            var heroSituation = new HeroSituationDecider(ActionEventList, HeroPosition).CalculateSituation();
            if (heroSituation == SituationType.RaiseFirstIn)
                return;

            var fileReaderFactoryParams = new FileReaderFactoryParams()
            {
                Situation = new VillainSituationDecider(ActionEventList, HeroPosition).CalculateSituation(),
                HeroPosition = new VillainPositionDecider(ActionEventList, HeroPosition).CalculateVillainPosition(),
                VillainPosition = HeroPosition
            };

            var fileReader = new FileReaderFactory().CreateInstance(fileReaderFactoryParams);
            VillainRange = fileReader.GetRange(new ActionParser());
        }

        public void Run(Hand heroHand)
        {
            HeroResult(heroHand);
            VillainResult();
        }
    }
}
