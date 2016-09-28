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

        public DecisionMakerResult Result { get; set; }

        public DecisionMaker(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
            Result = new DecisionMakerResult();
        }

        public void Run(Hand heroHand)
        {
            var heroSituationResult = new HeroSituationDecider(ActionEventList, HeroPosition).CalculateSituation();
            var villainSituationResult = new VillainSituationDecider(ActionEventList, HeroPosition).CalculateSituation();

            HeroRun(heroHand, heroSituationResult, villainSituationResult);
            VillainRun(heroSituationResult, villainSituationResult);
        }

        private void HeroRun(Hand heroHand, SituationDeciderResult heroSituationResult, SituationDeciderResult villainPositionResult)
        {
            var fileReaderFactoryParamsHero = new FileReaderFactoryParams()
            {
                Situation = heroSituationResult.Situation,
                HeroPosition = HeroPosition,
                VillainPosition = villainPositionResult.Position
            };

            var fileReaderHero = new FileReaderFactory().CreateInstance(fileReaderFactoryParamsHero);
            Result.HeroRange = fileReaderHero.GetRange(new ActionParser());
            Result.HeroAction = Result.HeroRange.GetAction(heroHand);
        }

        private void VillainRun(SituationDeciderResult heroSituationResult, SituationDeciderResult villainSituationResult)
        {
            if (heroSituationResult.Situation == SituationType.RaiseFirstIn)
                return;

            var fileReaderFactoryParamsVillain = new FileReaderFactoryParams()
            {
                Situation = villainSituationResult.Situation,
                HeroPosition = villainSituationResult.Position,
                VillainPosition = HeroPosition
            };

            var fileReaderVillain = new FileReaderFactory().CreateInstance(fileReaderFactoryParamsVillain);
            Result.VillainRange = fileReaderVillain.GetRange(new ActionParser());
        }
    }
}
