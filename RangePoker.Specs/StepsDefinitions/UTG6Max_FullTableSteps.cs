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

        [Given]
        public void GivenASixMaxPlayerTable()
        {
            Scenario = new ScenarioGenerator(Poker.Model.Enums.TableType.SixMax);
        }
        
        [Given]
        public void GivenTableIsFull()
        {

        }
        
        [Given]
        public void GivenHeroIsUTG()
        {
            Scenario.SetHeroPosition(Poker.Model.Enums.PositionType.LoJack);
        }
        
        [Given]
        public void GivenHeroHas_P0(int leftCardSuit, int leftCardRank, int rightCardSuit, int rightCardRank)
        {
            //var leftCard = new Card(Poker.Model.Enums.SuitType.Clubs, Poker.Model.Enums.RankType.Ace);
            //var rightCard = new Card(Poker.Model.Enums.SuitType.Diamonds, Poker.Model.Enums.RankType.Ace);

            var leftCard = new Card((SuitType)leftCardSuit, (RankType)leftCardRank);
            var rightCard = new Card((SuitType)rightCardSuit, (RankType)rightCardRank);

            var hand = new Hand(leftCard, rightCard);

            Scenario.SetHeroHand(hand);
        }
        
        [When]
        public void WhenActionReachesHero()
        {
            
        }
        
        [Then]
        public void ThenHeroIsToldTheActionToTake()
        {
            
        }
    }
}
