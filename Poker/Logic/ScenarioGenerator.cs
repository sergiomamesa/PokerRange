using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class ScenarioGenerator
    {
        public Table Table { get; set; }
        public Deck Deck = new Deck();
        private List<ActionEvent> ActionEventList { get; set; }
        private BoardStateType BoardState { get; set; }

        public ScenarioGenerator(TableType tableType)
        {
            Table = new TableFactory().CreateInstance(tableType);
            BoardState = BoardStateType.Preflop;
            ActionEventList = new List<ActionEvent>();
        }

        public void SetHeroPosition(PositionType position)
        {
            var seat = Table.Seats.FirstOrDefault(i => i.PositionType == position);
            seat.Player.IsHero = true;
        }

        public void SetHeroHand(Hand hand)
        {
            var seat = Table.Seats.FirstOrDefault(s => s.Player.IsHero);
            seat.Player.Hand = hand;
        }

        public void AddAction(PositionType position, ActionType action)
        {
            ActionEventList.Add(new ActionEvent(position, action));
        }

        public DecisionMakerResult Run()
        {
            var hero = Table.Seats.FirstOrDefault(s => s.Player.IsHero);
            var decisionMaker = new DecisionMaker(ActionEventList, hero.PositionType);
            decisionMaker.Run(hero.Player.Hand);

            var result = new DecisionMakerResult()
            {
                HeroAction = decisionMaker.Result.HeroAction,
                HeroRange = decisionMaker.Result.HeroRange,
                VillainRange = decisionMaker.Result.VillainRange
            };

            return result;
        }
    }
}
