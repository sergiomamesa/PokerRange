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

        public ScenarioGenerator(TableType tableType)
        {
            Table = new TableFactory().CreateInstance(tableType);
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

        public ActionType Run()
        {
            var decisicionMaker = new DecisionMaker(Table.Seats);
            
            throw new NotImplementedException();
        }
    }
}
