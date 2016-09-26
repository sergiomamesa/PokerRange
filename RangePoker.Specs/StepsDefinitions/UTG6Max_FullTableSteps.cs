using NUnit.Framework;
using Poker.Logic;
using Poker.Model;
using Poker.Model.Enums;
using System;
using TechTalk.SpecFlow;

namespace RangePoker.Specs.StepsDefinitions
{
    [Binding]
    public class UTG6Max_FullTableSteps
    {
        ScenarioGenerator Scenario;
        ActionType HeroActionType;

        [Given]
        public void GivenASixMaxPlayerTable()
        {
            Scenario = new ScenarioGenerator(TableType.SixMax);
        }

        [Given]
        public void GivenAFullRingPlayerTable()
        {
            Scenario = new ScenarioGenerator(TableType.FullRing);
        }

        [Given]
        public void GivenTableIsFull()
        {
            //No empty seats. Table is full by default.
        }

        [Given]
        public void GivenUTGPlusTwoRaises()
        {
            Scenario.AddAction(PositionType.UTGplus2, ActionType.Raise);
        }

        [Given]
        public void GivenHeroIsUTG()
        {
            Scenario.SetHeroPosition(PositionType.LoJack);
        }

        [Given]
        public void GivenHeroIsBB()
        {
            Scenario.SetHeroPosition(PositionType.BigBlind);
        }

        [Given]
        public void GivenHeroHas_P0__P1__P2__P3(int p0, int p1, int p2, int p3)
        {
            var leftCard = new Card((SuitType)p0, (RankType)p1);
            var rightCard = new Card((SuitType)p2, (RankType)p3);
            var hand = new Hand(leftCard, rightCard);

            Scenario.SetHeroHand(hand);
        }
        
        [When]
        public void WhenActionReachesHero()
        {
            HeroActionType = Scenario.Run();
        }

        [Then]
        public void ThenHeroIsToldToTakeAction_P0(int p0)
        {
            Assert.AreEqual(HeroActionType, (ActionType)p0);
        }
    }
}
