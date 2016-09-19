using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using TechTalk.SpecFlow;

namespace RangePoker.Specs
{
    [Binding]
    public class UTG6Max_FullTableSteps
    {
        ScenarioGenerator Scenario;
        ActionType ActionType;

        [Given]
        public void GivenASixMaxPlayerTable()
        {
            Scenario = new ScenarioGenerator(TableType.SixMax);
        }
        
        [Given]
        public void GivenTableIsFull()
        {
            //No empty seats
        }
        
        [Given]
        public void GivenHeroIsUTG()
        {
            Scenario.SetHeroPosition(PositionType.LoJack);
        }
        
        [Given]
        public void GivenHeroHas_P0(int leftCardSuit, int leftCardRank, int rightCardSuit, int rightCardRank)
        {
            var leftCard = new Card((SuitType)leftCardSuit, (RankType)leftCardRank);
            var rightCard = new Card((SuitType)rightCardSuit, (RankType)rightCardRank);
            var hand = new Hand(leftCard, rightCard);

            Scenario.SetHeroHand(hand);
        }
        
        [When]
        public void WhenActionReachesHero()
        {
            ActionType = Scenario.Run();
        }
        
        [Then]
        public void ThenHeroIsToldTheActionToTake()
        {
            Assert.AreEqual(ActionType, ActionType.Fold);
        }
    }
}
