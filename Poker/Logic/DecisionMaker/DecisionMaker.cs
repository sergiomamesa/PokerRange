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

        private DecisionMakerResult HeroResult(Hand hand)
        {
            var fileReaderFactoryParamsHero = new FileReaderFactoryParams()
            {
                Situation = new HeroSituationDecider(ActionEventList, HeroPosition).CalculateSituation(),
                HeroPosition = HeroPosition,
                VillainPosition = new VillainPositionDecider(ActionEventList, HeroPosition).CalculateVillainPosition()
            };

            var fileReaderHero = new FileReaderFactory().CreateInstance(fileReaderFactoryParamsHero);
            var heroRange = fileReaderHero.GetRange(new ActionParser());
            var heroAction = heroRange.GetAction(hand);

            var result = new DecisionMakerResult()
            {
                Action = heroAction,
                HeroRange = heroRange
            };

            return result;
        }

        private DecisionMakerResult VillainResult(DecisionMakerResult result)
        {
            var heroSituation = new HeroSituationDecider(ActionEventList, HeroPosition).CalculateSituation();
            if (heroSituation == SituationType.RaiseFirstIn)
                return result;

            var fileReaderFactoryParamsVillain = new FileReaderFactoryParams()
            {
                Situation = new VillainSituationDecider(ActionEventList, HeroPosition).CalculateSituation(),
                HeroPosition = new VillainPositionDecider(ActionEventList, HeroPosition).CalculateVillainPosition(),
                VillainPosition = HeroPosition
            };

            var fileReaderVillain = new FileReaderFactory().CreateInstance(fileReaderFactoryParamsVillain);
            var villainRange = fileReaderVillain.GetRange(new ActionParser());

            result.VillainRange = villainRange;
            return result;
        }

        public DecisionMakerResult Run(Hand heroHand)
        {
            var result = HeroResult(heroHand);
            result = VillainResult(result);

            return result;
        }
    }
}
